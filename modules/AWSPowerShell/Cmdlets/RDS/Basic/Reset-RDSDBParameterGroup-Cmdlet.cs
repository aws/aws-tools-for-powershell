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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modifies the parameters of a DB parameter group to the engine/system default value.
    /// To reset specific parameters, provide a list of the following: <c>ParameterName</c>
    /// and <c>ApplyMethod</c>. To reset the entire DB parameter group, specify the <c>DBParameterGroup</c>
    /// name and <c>ResetAllParameters</c> parameters. When resetting the entire group, dynamic
    /// parameters are updated immediately and static parameters are set to <c>pending-reboot</c>
    /// to take effect on the next DB instance restart or <c>RebootDBInstance</c> request.
    /// </summary>
    [Cmdlet("Reset", "RDSDBParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ResetDBParameterGroup API operation.", Operation = new[] {"ResetDBParameterGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.ResetDBParameterGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.RDS.Model.ResetDBParameterGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.RDS.Model.ResetDBParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ResetRDSDBParameterGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group.</para><para>Constraints:</para><ul><li><para>Must match the name of an existing <c>DBParameterGroup</c>.</para></li></ul>
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
        public System.String DBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>To reset the entire DB parameter group, specify the <c>DBParameterGroup</c> name and
        /// <c>ResetAllParameters</c> parameters. To reset specific parameters, provide a list
        /// of the following: <c>ParameterName</c> and <c>ApplyMethod</c>. A maximum of 20 parameters
        /// can be modified in a single request.</para><para><b>MySQL</b></para><para>Valid Values (for Apply method): <c>immediate</c> | <c>pending-reboot</c></para><para>You can use the immediate value with dynamic parameters only. You can use the <c>pending-reboot</c>
        /// value for both dynamic and static parameters, and changes are applied when DB instance
        /// reboots.</para><para><b>MariaDB</b></para><para>Valid Values (for Apply method): <c>immediate</c> | <c>pending-reboot</c></para><para>You can use the immediate value with dynamic parameters only. You can use the <c>pending-reboot</c>
        /// value for both dynamic and static parameters, and changes are applied when DB instance
        /// reboots.</para><para><b>Oracle</b></para><para>Valid Values (for Apply method): <c>pending-reboot</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.RDS.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter ResetAllParameter
        /// <summary>
        /// <para>
        /// <para>Specifies whether to reset all parameters in the DB parameter group to default values.
        /// By default, all parameters in the DB parameter group are reset to default values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResetAllParameters")]
        public System.Boolean? ResetAllParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBParameterGroupName'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ResetDBParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ResetDBParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBParameterGroupName";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBParameterGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-RDSDBParameterGroup (ResetDBParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ResetDBParameterGroupResponse, ResetRDSDBParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBParameterGroupName = this.DBParameterGroupName;
            #if MODULAR
            if (this.DBParameterGroupName == null && ParameterWasBound(nameof(this.DBParameterGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBParameterGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.RDS.Model.Parameter>(this.Parameter);
            }
            context.ResetAllParameter = this.ResetAllParameter;
            
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
            var request = new Amazon.RDS.Model.ResetDBParameterGroupRequest();
            
            if (cmdletContext.DBParameterGroupName != null)
            {
                request.DBParameterGroupName = cmdletContext.DBParameterGroupName;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ResetAllParameter != null)
            {
                request.ResetAllParameters = cmdletContext.ResetAllParameter.Value;
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
        
        private Amazon.RDS.Model.ResetDBParameterGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ResetDBParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ResetDBParameterGroup");
            try
            {
                return client.ResetDBParameterGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBParameterGroupName { get; set; }
            public List<Amazon.RDS.Model.Parameter> Parameter { get; set; }
            public System.Boolean? ResetAllParameter { get; set; }
            public System.Func<Amazon.RDS.Model.ResetDBParameterGroupResponse, ResetRDSDBParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBParameterGroupName;
        }
        
    }
}
