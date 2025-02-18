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

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Changes the settings for an existing DB proxy endpoint.
    /// </summary>
    [Cmdlet("Edit", "RDSDBProxyEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBProxyEndpoint")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBProxyEndpoint API operation.", Operation = new[] {"ModifyDBProxyEndpoint"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBProxyEndpointResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBProxyEndpoint or Amazon.RDS.Model.ModifyDBProxyEndpointResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBProxyEndpoint object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBProxyEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSDBProxyEndpointCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBProxyEndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the DB proxy sociated with the DB proxy endpoint that you want to modify.</para>
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
        public System.String DBProxyEndpointName { get; set; }
        #endregion
        
        #region Parameter NewDBProxyEndpointName
        /// <summary>
        /// <para>
        /// <para>The new identifier for the <c>DBProxyEndpoint</c>. An identifier must begin with a
        /// letter and must contain only ASCII letters, digits, and hyphens; it can't end with
        /// a hyphen or contain two consecutive hyphens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewDBProxyEndpointName { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs for the DB proxy endpoint. When the DB proxy endpoint uses
        /// a different VPC than the original proxy, you also specify a different set of security
        /// group IDs than for the original proxy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBProxyEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBProxyEndpointResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBProxyEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBProxyEndpoint";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBProxyEndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBProxyEndpoint (ModifyDBProxyEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBProxyEndpointResponse, EditRDSDBProxyEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBProxyEndpointName = this.DBProxyEndpointName;
            #if MODULAR
            if (this.DBProxyEndpointName == null && ParameterWasBound(nameof(this.DBProxyEndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBProxyEndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewDBProxyEndpointName = this.NewDBProxyEndpointName;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
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
            var request = new Amazon.RDS.Model.ModifyDBProxyEndpointRequest();
            
            if (cmdletContext.DBProxyEndpointName != null)
            {
                request.DBProxyEndpointName = cmdletContext.DBProxyEndpointName;
            }
            if (cmdletContext.NewDBProxyEndpointName != null)
            {
                request.NewDBProxyEndpointName = cmdletContext.NewDBProxyEndpointName;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
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
        
        private Amazon.RDS.Model.ModifyDBProxyEndpointResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBProxyEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBProxyEndpoint");
            try
            {
                return client.ModifyDBProxyEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBProxyEndpointName { get; set; }
            public System.String NewDBProxyEndpointName { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBProxyEndpointResponse, EditRDSDBProxyEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBProxyEndpoint;
        }
        
    }
}
