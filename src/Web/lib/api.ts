export type Report = { id: string; title: string; summary: string; createdAtUtc: string };

const baseUrl = process.env.API_BASE_URL ?? "http://localhost:5000";

export async function fetchReports(): Promise<Report[]> {
  const response = await fetch(`${baseUrl}/api/reports`, { cache: "no-store" });
  if (!response.ok) throw new Error("Unable to load reports");
  return response.json();
}

export async function fetchReport(id: string): Promise<Report> {
  const response = await fetch(`${baseUrl}/api/reports/${id}`, { cache: "no-store" });
  if (!response.ok) throw new Error("Unable to load report");
  return response.json();
}
