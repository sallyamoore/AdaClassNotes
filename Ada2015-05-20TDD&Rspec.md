# Testing!
Automated testing is an efficient way to optimize code. There's typically a next level of QA (human) testing as well.

## Test Driven Development
### technique that req's you to write code while simultaneously writing automated test code.
  1. Write a test that describes new feature
  2. Run it and watch it fail. Proves that it tests the functionality you haven't written yet.
  3. Write code to make it pass.
  4. Simplify.
  5. Repeat.

As code is written, you start to see the tests pass.

Referred to as Red, Green, Refactor.

Levels:
 * Unit testing. Most fine grain. Does line get expected result?
 * Integration testing. Testing integration of multiple units of code. When I put the units together, do they function properly as a block?


## Behavior Driven Development  
### develop with the behavior of the user/customer in mind.

* Hard b/c you have to develop excellent communication with all stakeholders.
* But works very well b/c you meet the needs more effectively.
* Ideally, there's a person who does the communicating with stakeholders, then relays this to developers.

# RSPEC
Lib folder - classes go here
Specs folder - tests go here

See chair_spec.rb in spec lib

Start by initializing rspec in the folder. Must do this everytime you create a NEW rspec project.
`rspec --init`

to run spec:
 `rspec spec`
 
 Add require to spec_helper file, e.g., require "bankaccounts"


 If you want to check a variable with values that depend:

 it "can make chairs with different materials" do
  local_chair = Chair.new("tweed")
  expect(local_chair.material).to eq("tweed")
end

## Context: Use, for example, with if blocks.

from betterspecs.org:

context 'when logged in' do
  it { is_expected.to respond_with 200 }
end
context 'when logged out' do
  it { is_expected.to respond_with 401 }
end
