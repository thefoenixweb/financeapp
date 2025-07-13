import React from 'react';

interface Props {
  symbol: string | null;
  onConfirm: () => void;
  onClose: () => void;
}

const DeleteConfirmationModal = ({ symbol, onConfirm, onClose }: Props) => {
  if (!symbol) return null; // Don't render if no symbol is selected

  return (
    <div className="fixed inset-0 bg-neutral-900 bg-opacity-50 flex items-center justify-center z-50 light-mode:bg-gray-600">
      <div className="bg-neutral-800 p-6 rounded-lg shadow-xl max-w-sm w-full light-mode:bg-white">
        <h3 className="text-lg font-bold mb-4 text-neutral-100 light-mode:text-neutral-900">Confirm Deletion</h3>
        <p className="mb-6 text-neutral-100 light-mode:text-neutral-900">Are you sure you want to delete <span className="font-semibold">{symbol}</span> from your portfolio?</p>
        <div className="flex justify-end space-x-4">
          <button
            onClick={onClose}
            className="px-4 py-2 bg-neutral-700 text-neutral-100 rounded-md hover:bg-neutral-600 transition-colors light-mode:bg-gray-200 light-mode:text-gray-800 light-mode:hover:bg-gray-300"
          >
            Cancel
          </button>
          <button
            onClick={onConfirm}
            className="px-4 py-2 bg-red-600 text-white rounded-md hover:bg-red-700 transition-colors"
          >
            Delete
          </button>
        </div>
      </div>
    </div>
  );
};

export default DeleteConfirmationModal; 