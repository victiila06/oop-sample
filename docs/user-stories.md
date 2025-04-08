# User Stories

This document contains user stories for the main features of the applicaction.

## US001: Create a Purchase Order
**As a** procurement manager,
**I want to** create a purchase order for a supplier,
**So that** I can manage the procurement process efficiently.

### Acceptance Criteria
### Scenario 1: Create a Purchase Order with Valid Supplier
**Given** A supplier with code "SUP123", name "Microsoft", and address "Redmond, NY, NY, USA",
**When** the procurement manager creates a purchase order with the supplier,
**Then** the purchase order should be created successfully with the supplier's details.

### Scenario 2: Create a Purchase Order with Invalid Supplier
**Given** A supplier with code "SUP123", name "Microsoft", and address "Redmond, NY, NY, USA",
**When** the procurement manager tries to create a purchase order with an invalid supplier code "SUP999",
**Then** an error message should be displayed indicating that the supplier does not exist.

