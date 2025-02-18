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
using System.Threading;
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Creates a version of a subscription definition which has already been defined.
    /// </summary>
    [Cmdlet("New", "GGSubscriptionDefinitionVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass CreateSubscriptionDefinitionVersion API operation.", Operation = new[] {"CreateSubscriptionDefinitionVersion"}, SelectReturnType = typeof(Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionResponse))]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionResponse",
        "This cmdlet returns an Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionResponse object containing multiple properties."
    )]
    public partial class NewGGSubscriptionDefinitionVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// A client token used to correlate requests
        /// and responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter SubscriptionDefinitionId
        /// <summary>
        /// <para>
        /// The ID of the subscription definition.
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
        public System.String SubscriptionDefinitionId { get; set; }
        #endregion
        
        #region Parameter Subscription
        /// <summary>
        /// <para>
        /// A list of subscriptions.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subscriptions")]
        public Amazon.Greengrass.Model.Subscription[] Subscription { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionResponse).
        /// Specifying the name of a property of type Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriptionDefinitionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGSubscriptionDefinitionVersion (CreateSubscriptionDefinitionVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionResponse, NewGGSubscriptionDefinitionVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmznClientToken = this.AmznClientToken;
            context.SubscriptionDefinitionId = this.SubscriptionDefinitionId;
            #if MODULAR
            if (this.SubscriptionDefinitionId == null && ParameterWasBound(nameof(this.SubscriptionDefinitionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionDefinitionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Subscription != null)
            {
                context.Subscription = new List<Amazon.Greengrass.Model.Subscription>(this.Subscription);
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
            var request = new Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            if (cmdletContext.SubscriptionDefinitionId != null)
            {
                request.SubscriptionDefinitionId = cmdletContext.SubscriptionDefinitionId;
            }
            if (cmdletContext.Subscription != null)
            {
                request.Subscriptions = cmdletContext.Subscription;
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
        
        private Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateSubscriptionDefinitionVersion");
            try
            {
                return client.CreateSubscriptionDefinitionVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AmznClientToken { get; set; }
            public System.String SubscriptionDefinitionId { get; set; }
            public List<Amazon.Greengrass.Model.Subscription> Subscription { get; set; }
            public System.Func<Amazon.Greengrass.Model.CreateSubscriptionDefinitionVersionResponse, NewGGSubscriptionDefinitionVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
