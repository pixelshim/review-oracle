export const metadata = {
  title: 'Review Oracle',
  description: 'Deterministic PR reviewer benchmark app'
};

export default function RootLayout({ children }) {
  return (
    <html lang="en">
      <body>{children}</body>
    </html>
  );
}
