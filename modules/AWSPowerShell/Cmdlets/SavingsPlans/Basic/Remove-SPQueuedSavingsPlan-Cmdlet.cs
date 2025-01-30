/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SavingsPlans;
using Amazon.SavingsPlans.Model;

namespace Amazon.PowerShell.Cmdlets.SP
{
    /// <summary>
    /// Deletes the queued purchase for the specified Savings Plan.
    /// </summary>
    [Cmdlet("Remove", "SPQueuedSavingsPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Savings Plans DeleteQueuedSavingsPlan API operation.", Operation = new[] {"DeleteQueuedSavingsPlan"}, SelectReturnType = typeof(Amazon.SavingsPlans.Model.DeleteQueuedSavingsPlanResponse))]
    [AWSCmdletOutput("None or Amazon.SavingsPlans.Model.DeleteQueuedSavingsPlanResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SavingsPlans.Model.DeleteQueuedSavingsPlanResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveSPQueuedSavingsPlanCmdlet : AmazonSavingsPlansClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SavingsPlanId
        /// <summary>
        /// <para>
        /// <para>The ID of the Savings Plan.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SavingsPlanId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SavingsPlans.Model.DeleteQueuedSavingsPlanResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SavingsPlanId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SavingsPlanId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SavingsPlanId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SavingsPlanId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SPQueuedSavingsPlan (DeleteQueuedSavingsPlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SavingsPlans.Model.DeleteQueuedSavingsPlanResponse, RemoveSPQueuedSavingsPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SavingsPlanId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SavingsPlanId = this.SavingsPlanId;
            #if MODULAR
            if (this.SavingsPlanId == null && ParameterWasBound(nameof(this.SavingsPlanId)))
            {
                WriteWarning("You are passing $null as a value for parameter SavingsPlanId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SavingsPlans.Model.DeleteQueuedSavingsPlanRequest();
            
            if (cmdletContext.SavingsPlanId != null)
            {
                request.SavingsPlanId = cmdletContext.SavingsPlanId;
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
        
        private Amazon.SavingsPlans.Model.DeleteQueuedSavingsPlanResponse CallAWSServiceOperation(IAmazonSavingsPlans client, Amazon.SavingsPlans.Model.DeleteQueuedSavingsPlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Savings Plans", "DeleteQueuedSavingsPlan");
            try
            {
                #if DESKTOP
                return client.DeleteQueuedSavingsPlan(request);
                #elif CORECLR
                return client.DeleteQueuedSavingsPlanAsync(request).GetAwaiter().GetResult();
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
            public System.String SavingsPlanId { get; set; }
            public System.Func<Amazon.SavingsPlans.Model.DeleteQueuedSavingsPlanResponse, RemoveSPQueuedSavingsPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
