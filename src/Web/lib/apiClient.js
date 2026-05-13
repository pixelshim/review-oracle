const API_BASE_URL = process.env.NEXT_PUBLIC_API_BASE_URL ?? 'http://localhost:5000';

async function request(path) {
  const response = await fetch(`${API_BASE_URL}${path}`, { cache: 'no-store' });

  if (!response.ok) {
    throw new Error(`API error: ${response.status}`);
  }

  return response.json();
}

export function getReports() {
  return request('/api/reports');
}

export function getReportById(id) {
  return request(`/api/reports/${id}`);
}
