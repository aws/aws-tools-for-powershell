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
using Amazon.Route53;
using Amazon.Route53.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Creates a health check source, which defines the virtual private cloud (VPC), subnets,
    /// and security groups from which Route 53 sends private endpoint health check requests.
    /// To use this operation, you must have the <c>route53:CreateHealthCheckSource</c> permission.
    /// You must also have permission to create a service-linked role.
    /// 
    ///  
    /// <para>
    /// Specify a VPC, one subnet in each Availability Zone that Route 53 uses for private
    /// endpoint health checks in the Amazon Web Services Region, and one or more security
    /// groups for each subnet. The security groups must allow outbound traffic to the endpoints
    /// that you want to check.
    /// </para><para>
    /// Route 53 creates a health check source asynchronously, and the initial <c>HealthCheckSourceStatus</c>
    /// is <c>CREATE_PENDING</c>. Call <c>GetHealthCheckSource</c> until the status is <c>CREATE_COMPLETED</c>
    /// before you create health checks that use the source. You can't change the configuration
    /// of a health check source after you create it.
    /// </para><para>
    /// If AWS Identity and Access Management (IAM) is still deleting the Route 53 service-linked
    /// role for your account, the request fails with <c>InvalidInput</c>. Retry after the
    /// deletion completes.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53HealthCheckSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateHealthCheckSourceResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 CreateHealthCheckSource API operation.", Operation = new[] {"CreateHealthCheckSource"}, SelectReturnType = typeof(Amazon.Route53.Model.CreateHealthCheckSourceResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateHealthCheckSourceResponse",
        "This cmdlet returns an Amazon.Route53.Model.CreateHealthCheckSourceResponse object containing multiple properties."
    )]
    public partial class NewR53HealthCheckSourceCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that ensures that the operation completes no more
        /// than one time. If you retry a <c>CreateHealthCheckSource</c> request with the same
        /// <c>CallerReference</c> and the same settings as a previous request, Route 53 returns
        /// the existing health check source without creating a duplicate. If that health check
        /// source has a status of <c>CREATE_FAILED</c>, Route 53 tries to create it again. To
        /// create a new health check source after a failure, specify a new value for <c>CallerReference</c>.
        /// If a health check source with the same <c>CallerReference</c> already exists and the
        /// settings differ, Route 53 returns a <c>HealthCheckSourceAlreadyExists</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter HealthCheckSourceConfig_SubnetConfigurationList
        /// <summary>
        /// <para>
        /// <para>A complex type that contains two or three <c>SubnetConfiguration</c> elements, one
        /// in each Availability Zone that Route 53 uses for private endpoint health checks in
        /// the Amazon Web Services Region. The Availability Zones must be distinct. Route 53
        /// creates network interfaces in each subnet and sends health check requests from all
        /// of them.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        public Amazon.Route53.Model.SubnetConfiguration[] HealthCheckSourceConfig_SubnetConfigurationList { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A complex type that contains a list of the tags that you want to apply to the health
        /// check source when you create it.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Route53.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter HealthCheckSourceConfig_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private cloud (VPC) that contains the subnets for the health
        /// check source. All subnets in <c>SubnetConfigurationList</c> must belong to this VPC.</para>
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
        public System.String HealthCheckSourceConfig_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.CreateHealthCheckSourceResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.CreateHealthCheckSourceResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HealthCheckSourceConfig_VpcId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53HealthCheckSource (CreateHealthCheckSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.CreateHealthCheckSourceResponse, NewR53HealthCheckSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CallerReference = this.CallerReference;
            context.HealthCheckSourceConfig_VpcId = this.HealthCheckSourceConfig_VpcId;
            #if MODULAR
            if (this.HealthCheckSourceConfig_VpcId == null && ParameterWasBound(nameof(this.HealthCheckSourceConfig_VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheckSourceConfig_VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.HealthCheckSourceConfig_SubnetConfigurationList != null)
            {
                context.HealthCheckSourceConfig_SubnetConfigurationList = new List<Amazon.Route53.Model.SubnetConfiguration>(this.HealthCheckSourceConfig_SubnetConfigurationList);
            }
            #if MODULAR
            if (this.HealthCheckSourceConfig_SubnetConfigurationList == null && ParameterWasBound(nameof(this.HealthCheckSourceConfig_SubnetConfigurationList)))
            {
                WriteWarning("You are passing $null as a value for parameter HealthCheckSourceConfig_SubnetConfigurationList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Route53.Model.Tag>(this.Tag);
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
            var request = new Amazon.Route53.Model.CreateHealthCheckSourceRequest();
            
            if (cmdletContext.CallerReference != null)
            {
                request.CallerReference = cmdletContext.CallerReference;
            }
            
             // populate HealthCheckSourceConfig
            var requestHealthCheckSourceConfigIsNull = true;
            request.HealthCheckSourceConfig = new Amazon.Route53.Model.HealthCheckSourceConfig();
            System.String requestHealthCheckSourceConfig_healthCheckSourceConfig_VpcId = null;
            if (cmdletContext.HealthCheckSourceConfig_VpcId != null)
            {
                requestHealthCheckSourceConfig_healthCheckSourceConfig_VpcId = cmdletContext.HealthCheckSourceConfig_VpcId;
            }
            if (requestHealthCheckSourceConfig_healthCheckSourceConfig_VpcId != null)
            {
                request.HealthCheckSourceConfig.VpcId = requestHealthCheckSourceConfig_healthCheckSourceConfig_VpcId;
                requestHealthCheckSourceConfigIsNull = false;
            }
            List<Amazon.Route53.Model.SubnetConfiguration> requestHealthCheckSourceConfig_healthCheckSourceConfig_SubnetConfigurationList = null;
            if (cmdletContext.HealthCheckSourceConfig_SubnetConfigurationList != null)
            {
                requestHealthCheckSourceConfig_healthCheckSourceConfig_SubnetConfigurationList = cmdletContext.HealthCheckSourceConfig_SubnetConfigurationList;
            }
            if (requestHealthCheckSourceConfig_healthCheckSourceConfig_SubnetConfigurationList != null)
            {
                request.HealthCheckSourceConfig.SubnetConfigurationList = requestHealthCheckSourceConfig_healthCheckSourceConfig_SubnetConfigurationList;
                requestHealthCheckSourceConfigIsNull = false;
            }
             // determine if request.HealthCheckSourceConfig should be set to null
            if (requestHealthCheckSourceConfigIsNull)
            {
                request.HealthCheckSourceConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Route53.Model.CreateHealthCheckSourceResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateHealthCheckSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "CreateHealthCheckSource");
            try
            {
                return client.CreateHealthCheckSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CallerReference { get; set; }
            public System.String HealthCheckSourceConfig_VpcId { get; set; }
            public List<Amazon.Route53.Model.SubnetConfiguration> HealthCheckSourceConfig_SubnetConfigurationList { get; set; }
            public List<Amazon.Route53.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Route53.Model.CreateHealthCheckSourceResponse, NewR53HealthCheckSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
