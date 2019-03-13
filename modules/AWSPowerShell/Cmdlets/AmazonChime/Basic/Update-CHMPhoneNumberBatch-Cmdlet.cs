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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Updates phone number product types. Choose from Amazon Chime Business Calling and
    /// Amazon Chime Voice Connector product types.
    /// </summary>
    [Cmdlet("Update", "CHMPhoneNumberBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.PhoneNumberError")]
    [AWSCmdlet("Calls the Amazon Chime BatchUpdatePhoneNumber API operation.", Operation = new[] {"BatchUpdatePhoneNumber"})]
    [AWSCmdletOutput("Amazon.Chime.Model.PhoneNumberError",
        "This cmdlet returns a collection of PhoneNumberError objects.",
        "The service call response (type Amazon.Chime.Model.BatchUpdatePhoneNumberResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCHMPhoneNumberBatchCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter UpdatePhoneNumberRequestItem
        /// <summary>
        /// <para>
        /// <para>The request containing the phone number IDs and product types to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UpdatePhoneNumberRequestItems")]
        public Amazon.Chime.Model.UpdatePhoneNumberRequestItem[] UpdatePhoneNumberRequestItem { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UpdatePhoneNumberRequestItem", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMPhoneNumberBatch (BatchUpdatePhoneNumber)"))
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
            
            if (this.UpdatePhoneNumberRequestItem != null)
            {
                context.UpdatePhoneNumberRequestItems = new List<Amazon.Chime.Model.UpdatePhoneNumberRequestItem>(this.UpdatePhoneNumberRequestItem);
            }
            
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
            var request = new Amazon.Chime.Model.BatchUpdatePhoneNumberRequest();
            
            if (cmdletContext.UpdatePhoneNumberRequestItems != null)
            {
                request.UpdatePhoneNumberRequestItems = cmdletContext.UpdatePhoneNumberRequestItems;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PhoneNumberErrors;
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
        
        private Amazon.Chime.Model.BatchUpdatePhoneNumberResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.BatchUpdatePhoneNumberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "BatchUpdatePhoneNumber");
            try
            {
                #if DESKTOP
                return client.BatchUpdatePhoneNumber(request);
                #elif CORECLR
                return client.BatchUpdatePhoneNumberAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Chime.Model.UpdatePhoneNumberRequestItem> UpdatePhoneNumberRequestItems { get; set; }
        }
        
    }
}
