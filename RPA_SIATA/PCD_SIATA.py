from selenium import webdriver
import numpy as np
import time
import json
import Data_Out as DO


def SIATA(url):

    driver = webdriver.Chrome("C:\Selenium\chromedriver.exe")
    driver.get(url)
    time.sleep(5)
    capas = driver.find_element_by_css_selector('#capas_detalle')
    capas_list = capas.find_elements_by_class_name('icon-remove-sign')
    for _ in capas_list:
        _.click()
    driver.find_element_by_css_selector('a[data-title="Redes"]').click()
    driver.find_element_by_css_selector(
        '#menu_div > ul > li:nth-child(5) > ul > li:nth-child(5) > a').click()
    time.sleep(2)
    driver.find_element_by_css_selector(
        '#C_00000000000000000000211capa_menu_check').click()
    driver.find_element_by_css_selector('a[data-title="Redes"]').click()
    time.sleep(5)
    points = driver.find_element_by_css_selector(
        '#mapa_div > div > div > div:nth-child(1) > div:nth-child(3) > div > div:nth-child(3)')
    points_list = points.find_elements_by_css_selector('div')
    driver.find_element_by_css_selector('div.checkbox-inline input').click()
    driver.find_element_by_css_selector(
        'div.panel-heading.inline div[style="float: right; margin-top: 1%;"] a.icon-chevron-down').click()
    data = dict()
    for i in range(1, len(points_list)+1):
        driver.find_element_by_css_selector(
            'div.panel-body div:nth-child('+str(i)+') input').click()
        time.sleep(0.1)
        try:
            driver.find_element_by_css_selector(
                '#mapa_div > div > div > div:nth-child(1) > div:nth-child(3) > div > div:nth-child(3) > div').click()
            stat_name = driver.find_element_by_css_selector(
                '#mapa_div > div > div > div:nth-child(1) > div:nth-child(3) > div > div:nth-child(3) > div').get_attribute('title').split('-')[0].strip()
            time.sleep(0.1)
            driver.find_element_by_css_selector(
                'div#capas_informacion div a[nombrepanel="Descripcion"]').click()
            time.sleep(0.3)
            items_table = driver.find_element_by_css_selector(
                'div.tab-pane.fade.mapa_feature_detalle_tabs_content.active.in div div:nth-child(1) tbody')
            items = items_table.find_elements_by_tag_name('tr')
            details = np.zeros(15).tolist()
            k = 0
            for _ in items:
                details[k] = _.find_element_by_css_selector(
                    'td:nth-child(3)').text
                k += 1
            level_txt = driver.find_element_by_css_selector(
                'div.tab-pane.fade.mapa_feature_detalle_tabs_content.active.in div div:nth-child(4) tbody tr:nth-child(7) td:nth-child(3)').text.split(' - ')
            level = level_txt[0]
            datelvl = level_txt[1]
            details[k] = datelvl
            details.append(level.strip())
            data.update({stat_name: {'codigo': details[0], 'barrio': details[1], 'comuna': details[2],
                                     'vereda': details[3], 'corregimiento': details[4], 'municipio': details[5], 'subcuenca': details[6], 'latitud': details[7], 'longitud': details[8], 'fecha_registro': details[9], 'nivel': details[-1]}})
            driver.find_element_by_css_selector(
                'div#capas_informacion div div div[style="float: right;"] a.icon-remove-sign').click()
        except:
            lll = 0
        if(i < len(points_list)):
            driver.find_element_by_css_selector(
                'a[href="#capas_detalle"]').click()
            driver.find_element_by_css_selector(
                'div.panel-body div:nth-child('+str(i)+') input').click()
    #DO.dataOut('data_SIATA.json', json.dumps(data))
    driver.quit()
    return data
