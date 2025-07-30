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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Initiates a directory assessment to validate your self-managed AD environment for
    /// hybrid domain join. The assessment checks compatibility and connectivity of the self-managed
    /// AD environment.
    /// 
    ///  
    /// <para>
    /// A directory assessment is automatically created when you create a hybrid directory.
    /// There are two types of assessments: <c>CUSTOMER</c> and <c>SYSTEM</c>. Your Amazon
    /// Web Services account has a limit of 100 <c>CUSTOMER</c> directory assessments.
    /// </para><para>
    /// The assessment process typically takes 30 minutes or more to complete. The assessment
    /// process is asynchronous and you can monitor it with <c>DescribeADAssessment</c>.
    /// </para><para>
    /// The <c>InstanceIds</c> must have a one-to-one correspondence with <c>CustomerDnsIps</c>,
    /// meaning that if the IP address for instance i-10243410 is 10.24.34.100 and the IP
    /// address for instance i-10243420 is 10.24.34.200, then the input arrays must maintain
    /// the same order relationship, either [10.24.34.100, 10.24.34.200] paired with [i-10243410,
    /// i-10243420] or [10.24.34.200, 10.24.34.100] paired with [i-10243420, i-10243410].
    /// </para><para>
    /// Note: You must provide exactly one <c>DirectoryId</c> or <c>AssessmentConfiguration</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "DSADAssessment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Directory Service StartADAssessment API operation.", Operation = new[] {"StartADAssessment"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.StartADAssessmentResponse))]
    [AWSCmdletOutput("System.String or Amazon.DirectoryService.Model.StartADAssessmentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DirectoryService.Model.StartADAssessmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDSADAssessmentCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssessmentConfiguration_CustomerDnsIp
        /// <summary>
        /// <para>
        /// <para>A list of IP addresses for the DNS servers or domain controllers in your self-managed
        /// AD that are tested during the assessment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssessmentConfiguration_CustomerDnsIps")]
        public System.String[] AssessmentConfiguration_CustomerDnsIp { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory for which to perform the assessment. This should be
        /// an existing directory. If the assessment is not for an existing directory, this parameter
        /// should be omitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter AssessmentConfiguration_DnsName
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name (FQDN) of the self-managed AD domain to assess.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AssessmentConfiguration_DnsName { get; set; }
        #endregion
        
        #region Parameter AssessmentConfiguration_InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the self-managed instances with SSM that are used to perform connectivity
        /// and validation tests.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssessmentConfiguration_InstanceIds")]
        public System.String[] AssessmentConfiguration_InstanceId { get; set; }
        #endregion
        
        #region Parameter AssessmentConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>By default, the service attaches a security group to allow network access to the self-managed
        /// nodes in your Amazon VPC. You can optionally supply your own security group that allows
        /// network traffic to and from your self-managed domain controllers outside of your Amazon
        /// VPC. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssessmentConfiguration_SecurityGroupIds")]
        public System.String[] AssessmentConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcSettings_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets for the directory servers. The two subnets must be
        /// in different Availability Zones. Directory Service creates a directory server and
        /// a DNS server in each of these subnets.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssessmentConfiguration_VpcSettings_SubnetIds")]
        public System.String[] VpcSettings_SubnetId { get; set; }
        #endregion
        
        #region Parameter VpcSettings_VpcId
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC in which to create the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssessmentConfiguration_VpcSettings_VpcId")]
        public System.String VpcSettings_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssessmentId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.StartADAssessmentResponse).
        /// Specifying the name of a property of type Amazon.DirectoryService.Model.StartADAssessmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssessmentId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DSADAssessment (StartADAssessment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.StartADAssessmentResponse, StartDSADAssessmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssessmentConfiguration_CustomerDnsIp != null)
            {
                context.AssessmentConfiguration_CustomerDnsIp = new List<System.String>(this.AssessmentConfiguration_CustomerDnsIp);
            }
            context.AssessmentConfiguration_DnsName = this.AssessmentConfiguration_DnsName;
            if (this.AssessmentConfiguration_InstanceId != null)
            {
                context.AssessmentConfiguration_InstanceId = new List<System.String>(this.AssessmentConfiguration_InstanceId);
            }
            if (this.AssessmentConfiguration_SecurityGroupId != null)
            {
                context.AssessmentConfiguration_SecurityGroupId = new List<System.String>(this.AssessmentConfiguration_SecurityGroupId);
            }
            if (this.VpcSettings_SubnetId != null)
            {
                context.VpcSettings_SubnetId = new List<System.String>(this.VpcSettings_SubnetId);
            }
            context.VpcSettings_VpcId = this.VpcSettings_VpcId;
            context.DirectoryId = this.DirectoryId;
            
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
            var request = new Amazon.DirectoryService.Model.StartADAssessmentRequest();
            
            
             // populate AssessmentConfiguration
            var requestAssessmentConfigurationIsNull = true;
            request.AssessmentConfiguration = new Amazon.DirectoryService.Model.AssessmentConfiguration();
            List<System.String> requestAssessmentConfiguration_assessmentConfiguration_CustomerDnsIp = null;
            if (cmdletContext.AssessmentConfiguration_CustomerDnsIp != null)
            {
                requestAssessmentConfiguration_assessmentConfiguration_CustomerDnsIp = cmdletContext.AssessmentConfiguration_CustomerDnsIp;
            }
            if (requestAssessmentConfiguration_assessmentConfiguration_CustomerDnsIp != null)
            {
                request.AssessmentConfiguration.CustomerDnsIps = requestAssessmentConfiguration_assessmentConfiguration_CustomerDnsIp;
                requestAssessmentConfigurationIsNull = false;
            }
            System.String requestAssessmentConfiguration_assessmentConfiguration_DnsName = null;
            if (cmdletContext.AssessmentConfiguration_DnsName != null)
            {
                requestAssessmentConfiguration_assessmentConfiguration_DnsName = cmdletContext.AssessmentConfiguration_DnsName;
            }
            if (requestAssessmentConfiguration_assessmentConfiguration_DnsName != null)
            {
                request.AssessmentConfiguration.DnsName = requestAssessmentConfiguration_assessmentConfiguration_DnsName;
                requestAssessmentConfigurationIsNull = false;
            }
            List<System.String> requestAssessmentConfiguration_assessmentConfiguration_InstanceId = null;
            if (cmdletContext.AssessmentConfiguration_InstanceId != null)
            {
                requestAssessmentConfiguration_assessmentConfiguration_InstanceId = cmdletContext.AssessmentConfiguration_InstanceId;
            }
            if (requestAssessmentConfiguration_assessmentConfiguration_InstanceId != null)
            {
                request.AssessmentConfiguration.InstanceIds = requestAssessmentConfiguration_assessmentConfiguration_InstanceId;
                requestAssessmentConfigurationIsNull = false;
            }
            List<System.String> requestAssessmentConfiguration_assessmentConfiguration_SecurityGroupId = null;
            if (cmdletContext.AssessmentConfiguration_SecurityGroupId != null)
            {
                requestAssessmentConfiguration_assessmentConfiguration_SecurityGroupId = cmdletContext.AssessmentConfiguration_SecurityGroupId;
            }
            if (requestAssessmentConfiguration_assessmentConfiguration_SecurityGroupId != null)
            {
                request.AssessmentConfiguration.SecurityGroupIds = requestAssessmentConfiguration_assessmentConfiguration_SecurityGroupId;
                requestAssessmentConfigurationIsNull = false;
            }
            Amazon.DirectoryService.Model.DirectoryVpcSettings requestAssessmentConfiguration_assessmentConfiguration_VpcSettings = null;
            
             // populate VpcSettings
            var requestAssessmentConfiguration_assessmentConfiguration_VpcSettingsIsNull = true;
            requestAssessmentConfiguration_assessmentConfiguration_VpcSettings = new Amazon.DirectoryService.Model.DirectoryVpcSettings();
            List<System.String> requestAssessmentConfiguration_assessmentConfiguration_VpcSettings_vpcSettings_SubnetId = null;
            if (cmdletContext.VpcSettings_SubnetId != null)
            {
                requestAssessmentConfiguration_assessmentConfiguration_VpcSettings_vpcSettings_SubnetId = cmdletContext.VpcSettings_SubnetId;
            }
            if (requestAssessmentConfiguration_assessmentConfiguration_VpcSettings_vpcSettings_SubnetId != null)
            {
                requestAssessmentConfiguration_assessmentConfiguration_VpcSettings.SubnetIds = requestAssessmentConfiguration_assessmentConfiguration_VpcSettings_vpcSettings_SubnetId;
                requestAssessmentConfiguration_assessmentConfiguration_VpcSettingsIsNull = false;
            }
            System.String requestAssessmentConfiguration_assessmentConfiguration_VpcSettings_vpcSettings_VpcId = null;
            if (cmdletContext.VpcSettings_VpcId != null)
            {
                requestAssessmentConfiguration_assessmentConfiguration_VpcSettings_vpcSettings_VpcId = cmdletContext.VpcSettings_VpcId;
            }
            if (requestAssessmentConfiguration_assessmentConfiguration_VpcSettings_vpcSettings_VpcId != null)
            {
                requestAssessmentConfiguration_assessmentConfiguration_VpcSettings.VpcId = requestAssessmentConfiguration_assessmentConfiguration_VpcSettings_vpcSettings_VpcId;
                requestAssessmentConfiguration_assessmentConfiguration_VpcSettingsIsNull = false;
            }
             // determine if requestAssessmentConfiguration_assessmentConfiguration_VpcSettings should be set to null
            if (requestAssessmentConfiguration_assessmentConfiguration_VpcSettingsIsNull)
            {
                requestAssessmentConfiguration_assessmentConfiguration_VpcSettings = null;
            }
            if (requestAssessmentConfiguration_assessmentConfiguration_VpcSettings != null)
            {
                request.AssessmentConfiguration.VpcSettings = requestAssessmentConfiguration_assessmentConfiguration_VpcSettings;
                requestAssessmentConfigurationIsNull = false;
            }
             // determine if request.AssessmentConfiguration should be set to null
            if (requestAssessmentConfigurationIsNull)
            {
                request.AssessmentConfiguration = null;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
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
        
        private Amazon.DirectoryService.Model.StartADAssessmentResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.StartADAssessmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "StartADAssessment");
            try
            {
                return client.StartADAssessmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AssessmentConfiguration_CustomerDnsIp { get; set; }
            public System.String AssessmentConfiguration_DnsName { get; set; }
            public List<System.String> AssessmentConfiguration_InstanceId { get; set; }
            public List<System.String> AssessmentConfiguration_SecurityGroupId { get; set; }
            public List<System.String> VpcSettings_SubnetId { get; set; }
            public System.String VpcSettings_VpcId { get; set; }
            public System.String DirectoryId { get; set; }
            public System.Func<Amazon.DirectoryService.Model.StartADAssessmentResponse, StartDSADAssessmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssessmentId;
        }
        
    }
}
