

interface ImportMetaEnv {
  readonly VITE_API_KEY: string;
  readonly VITE_TEST_VAR: string;
  // add other env variables here if needed
}

interface ImportMeta {
  readonly env: ImportMetaEnv;
}