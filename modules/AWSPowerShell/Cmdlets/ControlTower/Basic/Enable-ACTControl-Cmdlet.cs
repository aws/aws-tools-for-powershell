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
using Amazon.ControlTower;
using Amazon.ControlTower.Model;

namespace Amazon.PowerShell.Cmdlets.ACT
{
    /// <summary>
    /// This API call activates a control. It starts an asynchronous operation that creates
    /// Amazon Web Services resources on the specified organizational unit and the accounts
    /// it contains. The resources created will vary according to the control that you specify.
    /// For usage examples, see the <a href="https://docs.aws.amazon.com/controltower/latest/controlreference/control-api-examples-short.html"><i>Controls Reference Guide</i></a>.
    /// </summary>
    [Cmdlet("Enable", "ACTControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Control Tower EnableControl API operation.", Operation = new[] {"EnableControl"}, SelectReturnType = typeof(Amazon.ControlTower.Model.EnableControlResponse))]
    [AWSCmdletOutput("System.String or Amazon.ControlTower.Model.EnableControlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ControlTower.Model.EnableControlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableACTControlCmdlet : AmazonControlTowerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ControlIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the control. Only <b>Strongly recommended</b> and <b>Elective</b> controls
        /// are permitted, with the exception of the <b>Region deny</b> control. For information
        /// on how to find the <c>controlIdentifier</c>, see <a href="https://docs.aws.amazon.com/controltower/latest/APIReference/Welcome.html">the
        /// overview page</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ControlIdentifier { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of input parameter values, which are specified to configure the control when
        /// you enable it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.ControlTower.Model.EnabledControlParameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to be applied to the <c>EnabledControl</c> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TargetIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the organizational unit. For information on how to find the <c>targetIdentifier</c>,
        /// see <a href="https://docs.aws.amazon.com/controltower/latest/APIReference/Welcome.html">the
        /// overview page</a>.</para>
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
        public System.String TargetIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationIdentifier'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ControlTower.Model.EnableControlResponse).
        /// Specifying the name of a property of type Amazon.ControlTower.Model.EnableControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationIdentifier";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-ACTControl (EnableControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ControlTower.Model.EnableControlResponse, EnableACTControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ControlIdentifier = this.ControlIdentifier;
            #if MODULAR
            if (this.ControlIdentifier == null && ParameterWasBound(nameof(this.ControlIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.ControlTower.Model.EnabledControlParameter>(this.Parameter);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TargetIdentifier = this.TargetIdentifier;
            #if MODULAR
            if (this.TargetIdentifier == null && ParameterWasBound(nameof(this.TargetIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ControlTower.Model.EnableControlRequest();
            
            if (cmdletContext.ControlIdentifier != null)
            {
                request.ControlIdentifier = cmdletContext.ControlIdentifier;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetIdentifier != null)
            {
                request.TargetIdentifier = cmdletContext.TargetIdentifier;
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
        
        private Amazon.ControlTower.Model.EnableControlResponse CallAWSServiceOperation(IAmazonControlTower client, Amazon.ControlTower.Model.EnableControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Control Tower", "EnableControl");
            try
            {
                return client.EnableControlAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ControlIdentifier { get; set; }
            public List<Amazon.ControlTower.Model.EnabledControlParameter> Parameter { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TargetIdentifier { get; set; }
            public System.Func<Amazon.ControlTower.Model.EnableControlResponse, EnableACTControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationIdentifier;
        }
        
    }
}
