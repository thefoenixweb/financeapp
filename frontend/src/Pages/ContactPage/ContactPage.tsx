import React, { useState } from 'react';

const ContactPage: React.FC = () => {
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    subject: '',
    message: ''
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Add form submission logic here
    console.log('Form submitted:', formData);
  };

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-6">Contact Us</h1>
      <div className="max-w-2xl mx-auto">
        <form onSubmit={handleSubmit} className="bg-neutral-800 p-6 rounded-lg shadow light-mode:bg-white">
          <h2 className="text-2xl font-bold mb-6 text-neutral-100 light-mode:text-neutral-900">Contact Us</h2>
          <div className="mb-4">
            <label htmlFor="name" className="block text-sm font-medium text-neutral-400 light-mode:text-gray-700 mb-2">Name</label>
            <input
              type="text"
              id="name"
              name="name"
              value={formData.name}
              onChange={handleChange}
              className="w-full p-2 border border-neutral-600 rounded-md bg-neutral-700 text-neutral-100 light-mode:border-gray-300 light-mode:bg-white light-mode:text-gray-900"
              required
            />
          </div>
          <div className="mb-4">
            <label htmlFor="email" className="block text-sm font-medium text-neutral-400 light-mode:text-gray-700 mb-2">Email</label>
            <input
              type="email"
              id="email"
              name="email"
              value={formData.email}
              onChange={handleChange}
              className="w-full p-2 border border-neutral-600 rounded-md bg-neutral-700 text-neutral-100 light-mode:border-gray-300 light-mode:bg-white light-mode:text-gray-900"
              required
            />
          </div>
          <div className="mb-4">
            <label htmlFor="subject" className="block text-sm font-medium text-neutral-400 light-mode:text-gray-700 mb-2">Subject</label>
            <input
              type="text"
              id="subject"
              name="subject"
              value={formData.subject}
              onChange={handleChange}
              className="w-full p-2 border border-neutral-600 rounded-md bg-neutral-700 text-neutral-100 light-mode:border-gray-300 light-mode:bg-white light-mode:text-gray-900"
              required
            />
          </div>
          <div className="mb-6">
            <label htmlFor="message" className="block text-sm font-medium text-neutral-400 light-mode:text-gray-700 mb-2">Message</label>
            <textarea
              id="message"
              name="message"
              value={formData.message}
              onChange={handleChange}
              rows={5}
              className="w-full p-2 border border-neutral-600 rounded-md bg-neutral-700 text-neutral-100 light-mode:border-gray-300 light-mode:bg-white light-mode:text-gray-900"
              required
            ></textarea>
          </div>
          <button
            type="submit"
            className="w-full bg-primary-green text-white py-2 px-4 rounded-md hover:bg-primary-dark transition-colors"
          >
            Send Message
          </button>
        </form>
      </div>
    </div>
  );
};

export default ContactPage; 