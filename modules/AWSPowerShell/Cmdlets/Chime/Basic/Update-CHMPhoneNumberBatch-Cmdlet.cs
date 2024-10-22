/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates phone number product types or calling names. You can update one attribute
    /// at a time for each <c>UpdatePhoneNumberRequestItem</c>. For example, you can update
    /// the product type or the calling name.
    /// 
    ///  
    /// <para>
    /// For toll-free numbers, you cannot use the Amazon Chime Business Calling product type.
    /// For numbers outside the U.S., you must use the Amazon Chime SIP Media Application
    /// Dial-In product type.
    /// </para><para>
    /// Updates to outbound calling names can take up to 72 hours to complete. Pending updates
    /// to outbound calling names must be complete before you can request another update.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CHMPhoneNumberBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.PhoneNumberError")]
    [AWSCmdlet("Calls the Amazon Chime BatchUpdatePhoneNumber API operation.", Operation = new[] {"BatchUpdatePhoneNumber"}, SelectReturnType = typeof(Amazon.Chime.Model.BatchUpdatePhoneNumberResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.PhoneNumberError or Amazon.Chime.Model.BatchUpdatePhoneNumberResponse",
        "This cmdlet returns a collection of Amazon.Chime.Model.PhoneNumberError objects.",
        "The service call response (type Amazon.Chime.Model.BatchUpdatePhoneNumberResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCHMPhoneNumberBatchCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter UpdatePhoneNumberRequestItem
        /// <summary>
        /// <para>
        /// <para>The request containing the phone number IDs and product types or calling names to
        /// update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("UpdatePhoneNumberRequestItems")]
        public Amazon.Chime.Model.UpdatePhoneNumberRequestItem[] UpdatePhoneNumberRequestItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PhoneNumberErrors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.BatchUpdatePhoneNumberResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.BatchUpdatePhoneNumberResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PhoneNumberErrors";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UpdatePhoneNumberRequestItem), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMPhoneNumberBatch (BatchUpdatePhoneNumber)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.BatchUpdatePhoneNumberResponse, UpdateCHMPhoneNumberBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.UpdatePhoneNumberRequestItem != null)
            {
                context.UpdatePhoneNumberRequestItem = new List<Amazon.Chime.Model.UpdatePhoneNumberRequestItem>(this.UpdatePhoneNumberRequestItem);
            }
            #if MODULAR
            if (this.UpdatePhoneNumberRequestItem == null && ParameterWasBound(nameof(this.UpdatePhoneNumberRequestItem)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdatePhoneNumberRequestItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            
            if (cmdletContext.UpdatePhoneNumberRequestItem != null)
            {
                request.UpdatePhoneNumberRequestItems = cmdletContext.UpdatePhoneNumberRequestItem;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
            public List<Amazon.Chime.Model.UpdatePhoneNumberRequestItem> UpdatePhoneNumberRequestItem { get; set; }
            public System.Func<Amazon.Chime.Model.BatchUpdatePhoneNumberResponse, UpdateCHMPhoneNumberBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PhoneNumberErrors;
        }
        
    }
}
