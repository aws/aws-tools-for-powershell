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
using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;

namespace Amazon.PowerShell.Cmdlets.CWE
{
    /// <summary>
    /// Removes the specified targets from the specified rule. When the rule is triggered,
    /// those targets are no longer be invoked.
    /// 
    ///  
    /// <para>
    /// When you remove a target, when the associated rule triggers, removed targets might
    /// continue to be invoked. Allow a short period of time for changes to take effect.
    /// </para><para>
    /// This action can partially fail if too many requests are made at the same time. If
    /// that happens, <c>FailedEntryCount</c> is non-zero in the response and each entry in
    /// <c>FailedEntries</c> provides the ID of the failed target and the error code.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CWETarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.CloudWatchEvents.Model.RemoveTargetsResultEntry")]
    [AWSCmdlet("Calls the Amazon CloudWatch Events RemoveTargets API operation.", Operation = new[] {"RemoveTargets"}, SelectReturnType = typeof(Amazon.CloudWatchEvents.Model.RemoveTargetsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchEvents.Model.RemoveTargetsResultEntry or Amazon.CloudWatchEvents.Model.RemoveTargetsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchEvents.Model.RemoveTargetsResultEntry objects.",
        "The service call response (type Amazon.CloudWatchEvents.Model.RemoveTargetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveCWETargetCmdlet : AmazonCloudWatchEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventBusName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the event bus associated with the rule. If you omit this, the default
        /// event bus is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventBusName { get; set; }
        #endregion
        
        #region Parameter Enforce
        /// <summary>
        /// <para>
        /// <para>If this is a managed rule, created by an Amazon Web Services service on your behalf,
        /// you must specify <c>Force</c> as <c>True</c> to remove targets. This parameter is
        /// ignored for rules that are not managed rules. You can check whether a rule is a managed
        /// rule by using <c>DescribeRule</c> or <c>ListRules</c> and checking the <c>ManagedBy</c>
        /// field of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enforce { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The IDs of the targets to remove from the rule.</para>
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
        [Alias("Ids")]
        public System.String[] Id { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The name of the rule.</para>
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
        public System.String Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedEntries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchEvents.Model.RemoveTargetsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchEvents.Model.RemoveTargetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedEntries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Rule parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Rule' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Rule' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CWETarget (RemoveTargets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchEvents.Model.RemoveTargetsResponse, RemoveCWETargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Rule;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EventBusName = this.EventBusName;
            context.Enforce = this.Enforce;
            if (this.Id != null)
            {
                context.Id = new List<System.String>(this.Id);
            }
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Rule = this.Rule;
            #if MODULAR
            if (this.Rule == null && ParameterWasBound(nameof(this.Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchEvents.Model.RemoveTargetsRequest();
            
            if (cmdletContext.EventBusName != null)
            {
                request.EventBusName = cmdletContext.EventBusName;
            }
            if (cmdletContext.Enforce != null)
            {
                request.Force = cmdletContext.Enforce.Value;
            }
            if (cmdletContext.Id != null)
            {
                request.Ids = cmdletContext.Id;
            }
            if (cmdletContext.Rule != null)
            {
                request.Rule = cmdletContext.Rule;
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
        
        private Amazon.CloudWatchEvents.Model.RemoveTargetsResponse CallAWSServiceOperation(IAmazonCloudWatchEvents client, Amazon.CloudWatchEvents.Model.RemoveTargetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Events", "RemoveTargets");
            try
            {
                #if DESKTOP
                return client.RemoveTargets(request);
                #elif CORECLR
                return client.RemoveTargetsAsync(request).GetAwaiter().GetResult();
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
            public System.String EventBusName { get; set; }
            public System.Boolean? Enforce { get; set; }
            public List<System.String> Id { get; set; }
            public System.String Rule { get; set; }
            public System.Func<Amazon.CloudWatchEvents.Model.RemoveTargetsResponse, RemoveCWETargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedEntries;
        }
        
    }
}
