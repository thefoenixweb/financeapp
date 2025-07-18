/// <reference types="vite/client" />

interface ImportMetaEnv {
  readonly VITE_API_KEY: string
  readonly VITE_TEST_VAR: string
}

interface ImportMeta {
  readonly env: ImportMetaEnv
} 