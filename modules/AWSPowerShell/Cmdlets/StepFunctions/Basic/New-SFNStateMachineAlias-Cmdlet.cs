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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Creates an <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-state-machine-alias.html">alias</a>
    /// for a state machine that points to one or two <a href="https://docs.aws.amazon.com/step-functions/latest/dg/concepts-state-machine-version.html">versions</a>
    /// of the same state machine. You can set your application to call <a>StartExecution</a>
    /// with an alias and update the version the alias uses without changing the client's
    /// code.
    /// 
    ///  
    /// <para>
    /// You can also map an alias to split <a>StartExecution</a> requests between two versions
    /// of a state machine. To do this, add a second <c>RoutingConfig</c> object in the <c>routingConfiguration</c>
    /// parameter. You must also specify the percentage of execution run requests each version
    /// should receive in both <c>RoutingConfig</c> objects. Step Functions randomly chooses
    /// which version runs a given execution based on the percentage you specify.
    /// </para><para>
    /// To create an alias that points to a single version, specify a single <c>RoutingConfig</c>
    /// object with a <c>weight</c> set to 100.
    /// </para><para>
    /// You can create up to 100 aliases for each state machine. You must delete unused aliases
    /// using the <a>DeleteStateMachineAlias</a> API action.
    /// </para><para><c>CreateStateMachineAlias</c> is an idempotent API. Step Functions bases the idempotency
    /// check on the <c>stateMachineArn</c>, <c>description</c>, <c>name</c>, and <c>routingConfiguration</c>
    /// parameters. Requests that contain the same values for these parameters return a successful
    /// idempotent response without creating a duplicate resource.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>DescribeStateMachineAlias</a></para></li><li><para><a>ListStateMachineAliases</a></para></li><li><para><a>UpdateStateMachineAlias</a></para></li><li><para><a>DeleteStateMachineAlias</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "SFNStateMachineAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.StepFunctions.Model.CreateStateMachineAliasResponse")]
    [AWSCmdlet("Calls the AWS Step Functions CreateStateMachineAlias API operation.", Operation = new[] {"CreateStateMachineAlias"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.CreateStateMachineAliasResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.CreateStateMachineAliasResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.CreateStateMachineAliasResponse object containing multiple properties."
    )]
    public partial class NewSFNStateMachineAliasCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the state machine alias.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the state machine alias.</para><para>To avoid conflict with version ARNs, don't use an integer in the name of the alias.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoutingConfiguration
        /// <summary>
        /// <para>
        /// <para>The routing configuration of a state machine alias. The routing configuration shifts
        /// execution traffic between two state machine versions. <c>routingConfiguration</c>
        /// contains an array of <c>RoutingConfig</c> objects that specify up to two state machine
        /// versions. Step Functions then randomly choses which version to run an execution with
        /// based on the weight assigned to each <c>RoutingConfig</c>.</para>
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
        public Amazon.StepFunctions.Model.RoutingConfigurationListItem[] RoutingConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.CreateStateMachineAliasResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.CreateStateMachineAliasResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SFNStateMachineAlias (CreateStateMachineAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.CreateStateMachineAliasResponse, NewSFNStateMachineAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RoutingConfiguration != null)
            {
                context.RoutingConfiguration = new List<Amazon.StepFunctions.Model.RoutingConfigurationListItem>(this.RoutingConfiguration);
            }
            #if MODULAR
            if (this.RoutingConfiguration == null && ParameterWasBound(nameof(this.RoutingConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StepFunctions.Model.CreateStateMachineAliasRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoutingConfiguration != null)
            {
                request.RoutingConfiguration = cmdletContext.RoutingConfiguration;
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
        
        private Amazon.StepFunctions.Model.CreateStateMachineAliasResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.CreateStateMachineAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "CreateStateMachineAlias");
            try
            {
                #if DESKTOP
                return client.CreateStateMachineAlias(request);
                #elif CORECLR
                return client.CreateStateMachineAliasAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.StepFunctions.Model.RoutingConfigurationListItem> RoutingConfiguration { get; set; }
            public System.Func<Amazon.StepFunctions.Model.CreateStateMachineAliasResponse, NewSFNStateMachineAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
