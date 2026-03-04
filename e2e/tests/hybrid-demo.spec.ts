import { test, expect } from '@playwright/test'

test('home page renders', async ({ page }) => {
  await page.goto('/')
  await expect(page.getByText('Home Page')).toBeVisible()
})

test('inertia navigation to sub page works', async ({ page }) => {
  await page.goto('/')
  await page.getByRole('link', { name: 'Go to SubPage' }).click()
  await expect(page.getByText('Sub Page')).toBeVisible()
})

test('friendly URL JSON returns application/json with content api header', async ({ request }) => {
  const response = await request.get('/', {
    headers: {
      Accept: 'application/json',
      'Routed-By-ContentApi': '1',
    },
  })

  expect(response.ok()).toBeTruthy()
  expect(response.headers()['content-type']).toContain('application/json')
})
