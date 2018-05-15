/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.ALXB
{
    /// <summary>
    /// Associates a contact with a given address book.
    /// </summary>
    [Cmdlet("Add", "ALXBContactWithAddressBook", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Alexa For Business AssociateContactWithAddressBook API operation.", Operation = new[] {"AssociateContactWithAddressBook"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ContactArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AlexaForBusiness.Model.AssociateContactWithAddressBookResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddALXBContactWithAddressBookCmdlet : AmazonAlexaForBusinessClientCmdlet, IExecutor
    {
        
        #region Parameter AddressBookArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the address book with which to associate the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AddressBookArn { get; set; }
        #endregion
        
        #region Parameter ContactArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the contact to associate with an address book.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ContactArn { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ContactArn parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ContactArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-ALXBContactWithAddressBook (AssociateContactWithAddressBook)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AddressBookArn = this.AddressBookArn;
            context.ContactArn = this.ContactArn;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AlexaForBusiness.Model.AssociateContactWithAddressBookRequest();
            
            if (cmdletContext.AddressBookArn != null)
            {
                request.AddressBookArn = cmdletContext.AddressBookArn;
            }
            if (cmdletContext.ContactArn != null)
            {
                request.ContactArn = cmdletContext.ContactArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ContactArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AlexaForBusiness.Model.AssociateContactWithAddressBookResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.AssociateContactWithAddressBookRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "AssociateContactWithAddressBook");
            try
            {
                #if DESKTOP
                return client.AssociateContactWithAddressBook(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AssociateContactWithAddressBookAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AddressBookArn { get; set; }
            public System.String ContactArn { get; set; }
        }
        
    }
}
