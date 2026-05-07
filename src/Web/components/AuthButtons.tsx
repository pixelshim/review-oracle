"use client";

export function AuthButtons() {
  const handleLogin = () => alert("Placeholder login - wire Auth0 SDK later.");
  const handleLogout = () => alert("Placeholder logout - wire Auth0 SDK later.");

  return (
    <div style={{ display: "flex", gap: "0.5rem" }}>
      <button onClick={handleLogin}>Log In</button>
      <button onClick={handleLogout}>Log Out</button>
    </div>
  );
}
