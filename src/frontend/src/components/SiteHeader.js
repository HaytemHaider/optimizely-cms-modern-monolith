import { jsx as _jsx, jsxs as _jsxs } from "react/jsx-runtime";
import { Link } from '@inertiajs/react';
export function SiteHeader() {
    return (_jsx("header", { className: "border-b bg-white", children: _jsxs("div", { className: "mx-auto flex max-w-3xl items-center justify-between px-6 py-4", children: [_jsx(Link, { href: "/", className: "text-sm font-semibold text-slate-900", children: "Optimizely + Inertia Demo" }), _jsxs("div", { className: "flex gap-2 text-xs", children: [_jsx("span", { className: "rounded bg-blue-100 px-2 py-1 text-blue-700", children: "Rendered via Inertia" }), _jsx("span", { className: "rounded bg-emerald-100 px-2 py-1 text-emerald-700", children: "CDA in-process" })] })] }) }));
}
