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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modifies the parameters of a DB cluster parameter group. To modify more than one parameter,
    /// submit a list of the following: <c>ParameterName</c>, <c>ParameterValue</c>, and <c>ApplyMethod</c>.
    /// A maximum of 20 parameters can be modified in a single request.
    /// 
    ///  <important><para>
    /// There are two types of parameters - dynamic parameters and static parameters. Changes
    /// to dynamic parameters are applied to the DB cluster immediately without a reboot.
    /// Changes to static parameters are applied only after the DB cluster is rebooted, which
    /// can be done using <c>RebootDBCluster</c> operation. You can use the <i>Parameter Groups</i>
    /// option of the <a href="https://console.aws.amazon.com/rds/">Amazon RDS console</a>
    /// or the <c>DescribeDBClusterParameters</c> operation to verify that your DB cluster
    /// parameter group has been created or modified.
    /// </para></important><para>
    /// For more information on Amazon Aurora DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><para>
    /// For more information on Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/multi-az-db-clusters-concepts.html">
    /// Multi-AZ DB cluster deployments</a> in the <i>Amazon RDS User Guide.</i></para>
    /// </summary>
    [Cmdlet("Edit", "RDSDBClusterParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBClusterParameterGroup API operation.", Operation = new[] {"ModifyDBClusterParameterGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBClusterParameterGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.RDS.Model.ModifyDBClusterParameterGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBClusterParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSDBClusterParameterGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster parameter group to modify.</para>
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
        public System.String DBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of parameters in the DB cluster parameter group to modify.</para><para>Valid Values (for the application method): <c>immediate | pending-reboot</c></para><note><para>You can use the <c>immediate</c> value with dynamic parameters only. You can use the
        /// <c>pending-reboot</c> value for both dynamic and static parameters.</para><para>When the application method is <c>immediate</c>, changes to dynamic parameters are
        /// applied immediately to the DB clusters associated with the parameter group. When the
        /// application method is <c>pending-reboot</c>, changes to dynamic and static parameters
        /// are applied after a reboot without failover to the DB clusters associated with the
        /// parameter group.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Parameters")]
        public Amazon.RDS.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterParameterGroupName'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBClusterParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBClusterParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterParameterGroupName";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBClusterParameterGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBClusterParameterGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBClusterParameterGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterParameterGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBClusterParameterGroup (ModifyDBClusterParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBClusterParameterGroupResponse, EditRDSDBClusterParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBClusterParameterGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            #if MODULAR
            if (this.DBClusterParameterGroupName == null && ParameterWasBound(nameof(this.DBClusterParameterGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterParameterGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.RDS.Model.Parameter>(this.Parameter);
            }
            #if MODULAR
            if (this.Parameter == null && ParameterWasBound(nameof(this.Parameter)))
            {
                WriteWarning("You are passing $null as a value for parameter Parameter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.ModifyDBClusterParameterGroupRequest();
            
            if (cmdletContext.DBClusterParameterGroupName != null)
            {
                request.DBClusterParameterGroupName = cmdletContext.DBClusterParameterGroupName;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
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
        
        private Amazon.RDS.Model.ModifyDBClusterParameterGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBClusterParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBClusterParameterGroup");
            try
            {
                #if DESKTOP
                return client.ModifyDBClusterParameterGroup(request);
                #elif CORECLR
                return client.ModifyDBClusterParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String DBClusterParameterGroupName { get; set; }
            public List<Amazon.RDS.Model.Parameter> Parameter { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBClusterParameterGroupResponse, EditRDSDBClusterParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterParameterGroupName;
        }
        
    }
}
