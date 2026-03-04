import * as Accordion from '@radix-ui/react-accordion'

export function PageDebugCard({ payload }: { payload: unknown }) {
  return (
    <Accordion.Root type="single" collapsible className="rounded-lg border bg-white">
      <Accordion.Item value="debug">
        <Accordion.Header>
          <Accordion.Trigger className="w-full px-4 py-3 text-left text-sm font-medium">
            Debug payload (CDA-derived)
          </Accordion.Trigger>
        </Accordion.Header>
        <Accordion.Content className="border-t p-4">
          <pre className="overflow-x-auto text-xs text-slate-700">{JSON.stringify(payload, null, 2)}</pre>
        </Accordion.Content>
      </Accordion.Item>
    </Accordion.Root>
  )
}
