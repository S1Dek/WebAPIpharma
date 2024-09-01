from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
import time

# Set up the Chrome WebDriver
service = Service('C:\ChromeDriver\chromedriver_win32\chromedriver.exe')  # Path to the ChromeDriver executable
options = webdriver.ChromeOptions()
options.headless = True  # Run in headless mode
driver = webdriver.Chrome(service=service, options=options)

# Navigate to the website
driver.get('https://www.pharmaquinone.com/pharmaquinone-1-mct-oil-vitamin-k2-as-mk-7')

# Wait for dynamic content to load
time.sleep(5)  # You may need to adjust the wait time

# Extract the desired content
element = driver.find_element(By.XPATH, '//div[@class="text-block-236"]')  # Modify the selector as needed
data = element.text
print(data)

# Clean up
driver.quit()