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
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Updates a workgroup with the specified configuration settings. You can't update multiple
    /// parameters in one request. For example, you can update <c>baseCapacity</c> or <c>port</c>
    /// in a single request, but you can't update both in the same request.
    /// 
    ///  
    /// <para>
    /// VPC Block Public Access (BPA) enables you to block resources in VPCs and subnets that
    /// you own in a Region from reaching or being reached from the internet through internet
    /// gateways and egress-only internet gateways. If a workgroup is in an account with VPC
    /// BPA turned on, the following capabilities are blocked: 
    /// </para><ul><li><para>
    /// Creating a public access workgroup
    /// </para></li><li><para>
    /// Modifying a private workgroup to public
    /// </para></li><li><para>
    /// Adding a subnet with VPC BPA turned on to the workgroup when the workgroup is public
    /// </para></li></ul><para>
    /// For more information about VPC BPA, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/security-vpc-bpa.html">Block
    /// public access to VPCs and subnets</a> in the <i>Amazon VPC User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "RSSWorkgroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RedshiftServerless.Model.Workgroup")]
    [AWSCmdlet("Calls the Redshift Serverless UpdateWorkgroup API operation.", Operation = new[] {"UpdateWorkgroup"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.Workgroup or Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.Workgroup object.",
        "The service call response (type Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateRSSWorkgroupCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BaseCapacity
        /// <summary>
        /// <para>
        /// <para>The new base data warehouse capacity in Redshift Processing Units (RPUs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BaseCapacity { get; set; }
        #endregion
        
        #region Parameter ConfigParameter
        /// <summary>
        /// <para>
        /// <para>An array of parameters to set for advanced control over a database. The options are
        /// <c>auto_mv</c>, <c>datestyle</c>, <c>enable_case_sensitive_identifier</c>, <c>enable_user_activity_logging</c>,
        /// <c>query_group</c>, <c>search_path</c>, <c>require_ssl</c>, <c>use_fips_ssl</c>, and
        /// query monitoring metrics that let you define performance boundaries. For more information
        /// about query monitoring rules and available metrics, see <a href="https://docs.aws.amazon.com/redshift/latest/dg/cm-c-wlm-query-monitoring-rules.html#cm-c-wlm-query-monitoring-metrics-serverless">
        /// Query monitoring metrics for Amazon Redshift Serverless</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigParameters")]
        public Amazon.RedshiftServerless.Model.ConfigParameter[] ConfigParameter { get; set; }
        #endregion
        
        #region Parameter EnhancedVpcRouting
        /// <summary>
        /// <para>
        /// <para>The value that specifies whether to turn on enhanced virtual private cloud (VPC) routing,
        /// which forces Amazon Redshift Serverless to route traffic through your VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnhancedVpcRouting { get; set; }
        #endregion
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type that the workgroup supports. Possible values are <c>ipv4</c> and
        /// <c>dualstack</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IpAddressType { get; set; }
        #endregion
        
        #region Parameter PricePerformanceTarget_Level
        /// <summary>
        /// <para>
        /// <para>The target price performance level for the workgroup. Valid values include 1, 25,
        /// 50, 75, and 100. These correspond to the price performance levels LOW_COST, ECONOMICAL,
        /// BALANCED, RESOURCEFUL, and HIGH_PERFORMANCE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PricePerformanceTarget_Level { get; set; }
        #endregion
        
        #region Parameter MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum data-warehouse capacity Amazon Redshift Serverless uses to serve queries.
        /// The max capacity is specified in RPUs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxCapacity { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The custom port to use when connecting to a workgroup. Valid port ranges are 5431-5455
        /// and 8191-8215. The default is 5439.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether the workgroup can be accessible from a public network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>An array of security group IDs to associate with the workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter PricePerformanceTarget_Status
        /// <summary>
        /// <para>
        /// <para>Whether the price performance target is enabled for the workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RedshiftServerless.PerformanceTargetStatus")]
        public Amazon.RedshiftServerless.PerformanceTargetStatus PricePerformanceTarget_Status { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>An array of VPC subnet IDs to associate with the workgroup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter WorkgroupName
        /// <summary>
        /// <para>
        /// <para>The name of the workgroup to update. You can't update the name of a workgroup once
        /// it is created.</para>
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
        public System.String WorkgroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Workgroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Workgroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkgroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RSSWorkgroup (UpdateWorkgroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse, UpdateRSSWorkgroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BaseCapacity = this.BaseCapacity;
            if (this.ConfigParameter != null)
            {
                context.ConfigParameter = new List<Amazon.RedshiftServerless.Model.ConfigParameter>(this.ConfigParameter);
            }
            context.EnhancedVpcRouting = this.EnhancedVpcRouting;
            context.IpAddressType = this.IpAddressType;
            context.MaxCapacity = this.MaxCapacity;
            context.Port = this.Port;
            context.PricePerformanceTarget_Level = this.PricePerformanceTarget_Level;
            context.PricePerformanceTarget_Status = this.PricePerformanceTarget_Status;
            context.PubliclyAccessible = this.PubliclyAccessible;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            context.WorkgroupName = this.WorkgroupName;
            #if MODULAR
            if (this.WorkgroupName == null && ParameterWasBound(nameof(this.WorkgroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkgroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RedshiftServerless.Model.UpdateWorkgroupRequest();
            
            if (cmdletContext.BaseCapacity != null)
            {
                request.BaseCapacity = cmdletContext.BaseCapacity.Value;
            }
            if (cmdletContext.ConfigParameter != null)
            {
                request.ConfigParameters = cmdletContext.ConfigParameter;
            }
            if (cmdletContext.EnhancedVpcRouting != null)
            {
                request.EnhancedVpcRouting = cmdletContext.EnhancedVpcRouting.Value;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.MaxCapacity != null)
            {
                request.MaxCapacity = cmdletContext.MaxCapacity.Value;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            
             // populate PricePerformanceTarget
            var requestPricePerformanceTargetIsNull = true;
            request.PricePerformanceTarget = new Amazon.RedshiftServerless.Model.PerformanceTarget();
            System.Int32? requestPricePerformanceTarget_pricePerformanceTarget_Level = null;
            if (cmdletContext.PricePerformanceTarget_Level != null)
            {
                requestPricePerformanceTarget_pricePerformanceTarget_Level = cmdletContext.PricePerformanceTarget_Level.Value;
            }
            if (requestPricePerformanceTarget_pricePerformanceTarget_Level != null)
            {
                request.PricePerformanceTarget.Level = requestPricePerformanceTarget_pricePerformanceTarget_Level.Value;
                requestPricePerformanceTargetIsNull = false;
            }
            Amazon.RedshiftServerless.PerformanceTargetStatus requestPricePerformanceTarget_pricePerformanceTarget_Status = null;
            if (cmdletContext.PricePerformanceTarget_Status != null)
            {
                requestPricePerformanceTarget_pricePerformanceTarget_Status = cmdletContext.PricePerformanceTarget_Status;
            }
            if (requestPricePerformanceTarget_pricePerformanceTarget_Status != null)
            {
                request.PricePerformanceTarget.Status = requestPricePerformanceTarget_pricePerformanceTarget_Status;
                requestPricePerformanceTargetIsNull = false;
            }
             // determine if request.PricePerformanceTarget should be set to null
            if (requestPricePerformanceTargetIsNull)
            {
                request.PricePerformanceTarget = null;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.WorkgroupName != null)
            {
                request.WorkgroupName = cmdletContext.WorkgroupName;
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
        
        private Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.UpdateWorkgroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "UpdateWorkgroup");
            try
            {
                return client.UpdateWorkgroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? BaseCapacity { get; set; }
            public List<Amazon.RedshiftServerless.Model.ConfigParameter> ConfigParameter { get; set; }
            public System.Boolean? EnhancedVpcRouting { get; set; }
            public System.String IpAddressType { get; set; }
            public System.Int32? MaxCapacity { get; set; }
            public System.Int32? Port { get; set; }
            public System.Int32? PricePerformanceTarget_Level { get; set; }
            public Amazon.RedshiftServerless.PerformanceTargetStatus PricePerformanceTarget_Status { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public List<System.String> SubnetId { get; set; }
            public System.String WorkgroupName { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.UpdateWorkgroupResponse, UpdateRSSWorkgroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Workgroup;
        }
        
    }
}
