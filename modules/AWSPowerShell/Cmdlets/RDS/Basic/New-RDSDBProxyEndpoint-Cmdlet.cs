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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a <code>DBProxyEndpoint</code>. Only applies to proxies that are associated
    /// with Aurora DB clusters. You can use DB proxy endpoints to specify read/write or read-only
    /// access to the DB cluster. You can also use DB proxy endpoints to access a DB proxy
    /// through a different VPC than the proxy's default VPC.
    /// </summary>
    [Cmdlet("New", "RDSDBProxyEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBProxyEndpoint")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBProxyEndpoint API operation.", Operation = new[] {"CreateDBProxyEndpoint"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateDBProxyEndpointResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBProxyEndpoint or Amazon.RDS.Model.CreateDBProxyEndpointResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBProxyEndpoint object.",
        "The service call response (type Amazon.RDS.Model.CreateDBProxyEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSDBProxyEndpointCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBProxyEndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the DB proxy endpoint to create.</para>
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
        
        #region Parameter DBProxyName
        /// <summary>
        /// <para>
        /// <para>The name of the DB proxy associated with the DB proxy endpoint that you create.</para>
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
        public System.String DBProxyName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetRole
        /// <summary>
        /// <para>
        /// <para>The role of the DB proxy endpoint. The role determines whether the endpoint can be
        /// used for read/write or only read operations. The default is <code>READ_WRITE</code>.
        /// The only role that proxies for RDS for Microsoft SQL Server support is <code>READ_WRITE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.DBProxyEndpointTargetRole")]
        public Amazon.RDS.DBProxyEndpointTargetRole TargetRole { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs for the DB proxy endpoint that you create. You can specify
        /// a different set of security group IDs than for the original DB proxy. The default
        /// is the default security group for the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcSubnetId
        /// <summary>
        /// <para>
        /// <para>The VPC subnet IDs for the DB proxy endpoint that you create. You can specify a different
        /// set of subnet IDs than for the original DB proxy.</para>
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
        [Alias("VpcSubnetIds")]
        public System.String[] VpcSubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBProxyEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateDBProxyEndpointResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateDBProxyEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBProxyEndpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBProxyEndpointName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBProxyEndpointName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBProxyEndpointName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBProxyEndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBProxyEndpoint (CreateDBProxyEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateDBProxyEndpointResponse, NewRDSDBProxyEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBProxyEndpointName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBProxyEndpointName = this.DBProxyEndpointName;
            #if MODULAR
            if (this.DBProxyEndpointName == null && ParameterWasBound(nameof(this.DBProxyEndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBProxyEndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBProxyName = this.DBProxyName;
            #if MODULAR
            if (this.DBProxyName == null && ParameterWasBound(nameof(this.DBProxyName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBProxyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetRole = this.TargetRole;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
            }
            if (this.VpcSubnetId != null)
            {
                context.VpcSubnetId = new List<System.String>(this.VpcSubnetId);
            }
            #if MODULAR
            if (this.VpcSubnetId == null && ParameterWasBound(nameof(this.VpcSubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcSubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.CreateDBProxyEndpointRequest();
            
            if (cmdletContext.DBProxyEndpointName != null)
            {
                request.DBProxyEndpointName = cmdletContext.DBProxyEndpointName;
            }
            if (cmdletContext.DBProxyName != null)
            {
                request.DBProxyName = cmdletContext.DBProxyName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetRole != null)
            {
                request.TargetRole = cmdletContext.TargetRole;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
            }
            if (cmdletContext.VpcSubnetId != null)
            {
                request.VpcSubnetIds = cmdletContext.VpcSubnetId;
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
        
        private Amazon.RDS.Model.CreateDBProxyEndpointResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateDBProxyEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateDBProxyEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateDBProxyEndpoint(request);
                #elif CORECLR
                return client.CreateDBProxyEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String DBProxyEndpointName { get; set; }
            public System.String DBProxyName { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public Amazon.RDS.DBProxyEndpointTargetRole TargetRole { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public List<System.String> VpcSubnetId { get; set; }
            public System.Func<Amazon.RDS.Model.CreateDBProxyEndpointResponse, NewRDSDBProxyEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBProxyEndpoint;
        }
        
    }
}
