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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Specifies the action that is to be applied to the findings that match the filter.
    /// </summary>
    [Cmdlet("Update", "INS2Filter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Inspector2 UpdateFilter API operation.", Operation = new[] {"UpdateFilter"}, SelectReturnType = typeof(Amazon.Inspector2.Model.UpdateFilterResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector2.Model.UpdateFilterResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Inspector2.Model.UpdateFilterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateINS2FilterCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>Specifies the action that is to be applied to the findings that match the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.FilterAction")]
        public Amazon.Inspector2.FilterAction Action { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_AwsAccountId
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon Web Services account IDs used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_AwsAccountId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeVulnerabilityDetectorName
        /// <summary>
        /// <para>
        /// <para>The name of the detector used to identify a code vulnerability in a Lambda function
        /// used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_CodeVulnerabilityDetectorName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeVulnerabilityDetectorTag
        /// <summary>
        /// <para>
        /// <para>The detector type tag associated with the vulnerability used to filter findings. Detector
        /// tags group related vulnerabilities by common themes or tactics. For a list of available
        /// tags by programming language, see <a href="https://docs.aws.amazon.com/codeguru/detector-library/java/tags/">Java
        /// tags</a>, or <a href="https://docs.aws.amazon.com/codeguru/detector-library/python/tags/">Python
        /// tags</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_CodeVulnerabilityDetectorTags")]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_CodeVulnerabilityDetectorTag { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeVulnerabilityFilePath
        /// <summary>
        /// <para>
        /// <para>The file path to the file in a Lambda function that contains a code vulnerability
        /// used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_CodeVulnerabilityFilePath { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ComponentId
        /// <summary>
        /// <para>
        /// <para>Details of the component IDs used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ComponentId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ComponentType
        /// <summary>
        /// <para>
        /// <para>Details of the component types used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ComponentType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Ec2InstanceImageId
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon EC2 instance image IDs used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Ec2InstanceImageId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Ec2InstanceSubnetId
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon EC2 instance subnet IDs used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Ec2InstanceSubnetId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Ec2InstanceVpcId
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon EC2 instance VPC IDs used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Ec2InstanceVpcId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageArchitecture
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon ECR image architecture types used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageArchitecture { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageHash
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon ECR image hashes used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageHash { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImagePushedAt
        /// <summary>
        /// <para>
        /// <para>Details on the Amazon ECR image push date and time used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_EcrImagePushedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageRegistry
        /// <summary>
        /// <para>
        /// <para>Details on the Amazon ECR registry used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageRegistry { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageRepositoryName
        /// <summary>
        /// <para>
        /// <para>Details on the name of the Amazon ECR repository used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageRepositoryName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageTag
        /// <summary>
        /// <para>
        /// <para>The tags attached to the Amazon ECR container image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_EcrImageTags")]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageTag { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EpssScore
        /// <summary>
        /// <para>
        /// <para>The EPSS score used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.NumberFilter[] FilterCriteria_EpssScore { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ExploitAvailable
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda findings by the availability of exploits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ExploitAvailable { get; set; }
        #endregion
        
        #region Parameter FilterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the filter to update.</para>
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
        public System.String FilterArn { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FindingArn
        /// <summary>
        /// <para>
        /// <para>Details on the finding ARNs used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_FindingArn { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FindingStatus
        /// <summary>
        /// <para>
        /// <para>Details on the finding status types used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_FindingStatus { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FindingType
        /// <summary>
        /// <para>
        /// <para>Details on the finding types used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_FindingType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FirstObservedAt
        /// <summary>
        /// <para>
        /// <para>Details on the date and time a finding was first seen used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_FirstObservedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FixAvailable
        /// <summary>
        /// <para>
        /// <para>Details on whether a fix is available through a version update. This value can be
        /// <c>YES</c>, <c>NO</c>, or <c>PARTIAL</c>. A <c>PARTIAL</c> fix means that some, but
        /// not all, of the packages identified in the finding have fixes available through updated
        /// versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_FixAvailable { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_InspectorScore
        /// <summary>
        /// <para>
        /// <para>The Amazon Inspector score to filter on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.NumberFilter[] FilterCriteria_InspectorScore { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by execution role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_LambdaFunctionExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionLastModifiedAt
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by the date and time that
        /// a user last updated the configuration, in <a href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO
        /// 8601 format</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_LambdaFunctionLastModifiedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionLayer
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by the function's <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-layers.html">
        /// layers</a>. A Lambda function can have up to five layers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_LambdaFunctionLayers")]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_LambdaFunctionLayer { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionName
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by the name of the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_LambdaFunctionName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionRuntime
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by the runtime environment
        /// for the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_LambdaFunctionRuntime { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LastObservedAt
        /// <summary>
        /// <para>
        /// <para>Details on the date and time a finding was last seen used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_LastObservedAt { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_NetworkProtocol
        /// <summary>
        /// <para>
        /// <para>Details on network protocol used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_NetworkProtocol { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_PortRange
        /// <summary>
        /// <para>
        /// <para>Details on the port ranges used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.PortRangeFilter[] FilterCriteria_PortRange { get; set; }
        #endregion
        
        #region Parameter Reason
        /// <summary>
        /// <para>
        /// <para>The reason the filter was updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reason { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_RelatedVulnerability
        /// <summary>
        /// <para>
        /// <para>Details on the related vulnerabilities used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_RelatedVulnerabilities")]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_RelatedVulnerability { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ResourceId
        /// <summary>
        /// <para>
        /// <para>Details on the resource IDs used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ResourceId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ResourceTag
        /// <summary>
        /// <para>
        /// <para>Details on the resource tags used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_ResourceTags")]
        public Amazon.Inspector2.Model.MapFilter[] FilterCriteria_ResourceTag { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ResourceType
        /// <summary>
        /// <para>
        /// <para>Details on the resource types used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ResourceType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Severity
        /// <summary>
        /// <para>
        /// <para>Details on the severity used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Severity { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Title
        /// <summary>
        /// <para>
        /// <para>Details on the finding title used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Title { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_UpdatedAt
        /// <summary>
        /// <para>
        /// <para>Details on the date and time a finding was last updated at used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_UpdatedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_VendorSeverity
        /// <summary>
        /// <para>
        /// <para>Details on the vendor severity used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_VendorSeverity { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_VulnerabilityId
        /// <summary>
        /// <para>
        /// <para>Details on the vulnerability ID used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_VulnerabilityId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_VulnerabilitySource
        /// <summary>
        /// <para>
        /// <para>Details on the vulnerability type used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_VulnerabilitySource { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_VulnerablePackage
        /// <summary>
        /// <para>
        /// <para>Details on the vulnerable packages used to filter findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_VulnerablePackages")]
        public Amazon.Inspector2.Model.PackageFilter[] FilterCriteria_VulnerablePackage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.UpdateFilterResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.UpdateFilterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FilterArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INS2Filter (UpdateFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.UpdateFilterResponse, UpdateINS2FilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            context.Description = this.Description;
            context.FilterArn = this.FilterArn;
            #if MODULAR
            if (this.FilterArn == null && ParameterWasBound(nameof(this.FilterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FilterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FilterCriteria_AwsAccountId != null)
            {
                context.FilterCriteria_AwsAccountId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_AwsAccountId);
            }
            if (this.FilterCriteria_CodeVulnerabilityDetectorName != null)
            {
                context.FilterCriteria_CodeVulnerabilityDetectorName = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_CodeVulnerabilityDetectorName);
            }
            if (this.FilterCriteria_CodeVulnerabilityDetectorTag != null)
            {
                context.FilterCriteria_CodeVulnerabilityDetectorTag = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_CodeVulnerabilityDetectorTag);
            }
            if (this.FilterCriteria_CodeVulnerabilityFilePath != null)
            {
                context.FilterCriteria_CodeVulnerabilityFilePath = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_CodeVulnerabilityFilePath);
            }
            if (this.FilterCriteria_ComponentId != null)
            {
                context.FilterCriteria_ComponentId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ComponentId);
            }
            if (this.FilterCriteria_ComponentType != null)
            {
                context.FilterCriteria_ComponentType = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ComponentType);
            }
            if (this.FilterCriteria_Ec2InstanceImageId != null)
            {
                context.FilterCriteria_Ec2InstanceImageId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Ec2InstanceImageId);
            }
            if (this.FilterCriteria_Ec2InstanceSubnetId != null)
            {
                context.FilterCriteria_Ec2InstanceSubnetId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Ec2InstanceSubnetId);
            }
            if (this.FilterCriteria_Ec2InstanceVpcId != null)
            {
                context.FilterCriteria_Ec2InstanceVpcId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Ec2InstanceVpcId);
            }
            if (this.FilterCriteria_EcrImageArchitecture != null)
            {
                context.FilterCriteria_EcrImageArchitecture = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageArchitecture);
            }
            if (this.FilterCriteria_EcrImageHash != null)
            {
                context.FilterCriteria_EcrImageHash = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageHash);
            }
            if (this.FilterCriteria_EcrImagePushedAt != null)
            {
                context.FilterCriteria_EcrImagePushedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_EcrImagePushedAt);
            }
            if (this.FilterCriteria_EcrImageRegistry != null)
            {
                context.FilterCriteria_EcrImageRegistry = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageRegistry);
            }
            if (this.FilterCriteria_EcrImageRepositoryName != null)
            {
                context.FilterCriteria_EcrImageRepositoryName = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageRepositoryName);
            }
            if (this.FilterCriteria_EcrImageTag != null)
            {
                context.FilterCriteria_EcrImageTag = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageTag);
            }
            if (this.FilterCriteria_EpssScore != null)
            {
                context.FilterCriteria_EpssScore = new List<Amazon.Inspector2.Model.NumberFilter>(this.FilterCriteria_EpssScore);
            }
            if (this.FilterCriteria_ExploitAvailable != null)
            {
                context.FilterCriteria_ExploitAvailable = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ExploitAvailable);
            }
            if (this.FilterCriteria_FindingArn != null)
            {
                context.FilterCriteria_FindingArn = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_FindingArn);
            }
            if (this.FilterCriteria_FindingStatus != null)
            {
                context.FilterCriteria_FindingStatus = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_FindingStatus);
            }
            if (this.FilterCriteria_FindingType != null)
            {
                context.FilterCriteria_FindingType = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_FindingType);
            }
            if (this.FilterCriteria_FirstObservedAt != null)
            {
                context.FilterCriteria_FirstObservedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_FirstObservedAt);
            }
            if (this.FilterCriteria_FixAvailable != null)
            {
                context.FilterCriteria_FixAvailable = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_FixAvailable);
            }
            if (this.FilterCriteria_InspectorScore != null)
            {
                context.FilterCriteria_InspectorScore = new List<Amazon.Inspector2.Model.NumberFilter>(this.FilterCriteria_InspectorScore);
            }
            if (this.FilterCriteria_LambdaFunctionExecutionRoleArn != null)
            {
                context.FilterCriteria_LambdaFunctionExecutionRoleArn = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_LambdaFunctionExecutionRoleArn);
            }
            if (this.FilterCriteria_LambdaFunctionLastModifiedAt != null)
            {
                context.FilterCriteria_LambdaFunctionLastModifiedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_LambdaFunctionLastModifiedAt);
            }
            if (this.FilterCriteria_LambdaFunctionLayer != null)
            {
                context.FilterCriteria_LambdaFunctionLayer = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_LambdaFunctionLayer);
            }
            if (this.FilterCriteria_LambdaFunctionName != null)
            {
                context.FilterCriteria_LambdaFunctionName = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_LambdaFunctionName);
            }
            if (this.FilterCriteria_LambdaFunctionRuntime != null)
            {
                context.FilterCriteria_LambdaFunctionRuntime = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_LambdaFunctionRuntime);
            }
            if (this.FilterCriteria_LastObservedAt != null)
            {
                context.FilterCriteria_LastObservedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_LastObservedAt);
            }
            if (this.FilterCriteria_NetworkProtocol != null)
            {
                context.FilterCriteria_NetworkProtocol = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_NetworkProtocol);
            }
            if (this.FilterCriteria_PortRange != null)
            {
                context.FilterCriteria_PortRange = new List<Amazon.Inspector2.Model.PortRangeFilter>(this.FilterCriteria_PortRange);
            }
            if (this.FilterCriteria_RelatedVulnerability != null)
            {
                context.FilterCriteria_RelatedVulnerability = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_RelatedVulnerability);
            }
            if (this.FilterCriteria_ResourceId != null)
            {
                context.FilterCriteria_ResourceId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ResourceId);
            }
            if (this.FilterCriteria_ResourceTag != null)
            {
                context.FilterCriteria_ResourceTag = new List<Amazon.Inspector2.Model.MapFilter>(this.FilterCriteria_ResourceTag);
            }
            if (this.FilterCriteria_ResourceType != null)
            {
                context.FilterCriteria_ResourceType = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ResourceType);
            }
            if (this.FilterCriteria_Severity != null)
            {
                context.FilterCriteria_Severity = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Severity);
            }
            if (this.FilterCriteria_Title != null)
            {
                context.FilterCriteria_Title = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Title);
            }
            if (this.FilterCriteria_UpdatedAt != null)
            {
                context.FilterCriteria_UpdatedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_UpdatedAt);
            }
            if (this.FilterCriteria_VendorSeverity != null)
            {
                context.FilterCriteria_VendorSeverity = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_VendorSeverity);
            }
            if (this.FilterCriteria_VulnerabilityId != null)
            {
                context.FilterCriteria_VulnerabilityId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_VulnerabilityId);
            }
            if (this.FilterCriteria_VulnerabilitySource != null)
            {
                context.FilterCriteria_VulnerabilitySource = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_VulnerabilitySource);
            }
            if (this.FilterCriteria_VulnerablePackage != null)
            {
                context.FilterCriteria_VulnerablePackage = new List<Amazon.Inspector2.Model.PackageFilter>(this.FilterCriteria_VulnerablePackage);
            }
            context.Name = this.Name;
            context.Reason = this.Reason;
            
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
            var request = new Amazon.Inspector2.Model.UpdateFilterRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FilterArn != null)
            {
                request.FilterArn = cmdletContext.FilterArn;
            }
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Inspector2.Model.FilterCriteria();
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_AwsAccountId = null;
            if (cmdletContext.FilterCriteria_AwsAccountId != null)
            {
                requestFilterCriteria_filterCriteria_AwsAccountId = cmdletContext.FilterCriteria_AwsAccountId;
            }
            if (requestFilterCriteria_filterCriteria_AwsAccountId != null)
            {
                request.FilterCriteria.AwsAccountId = requestFilterCriteria_filterCriteria_AwsAccountId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorName = null;
            if (cmdletContext.FilterCriteria_CodeVulnerabilityDetectorName != null)
            {
                requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorName = cmdletContext.FilterCriteria_CodeVulnerabilityDetectorName;
            }
            if (requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorName != null)
            {
                request.FilterCriteria.CodeVulnerabilityDetectorName = requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorTag = null;
            if (cmdletContext.FilterCriteria_CodeVulnerabilityDetectorTag != null)
            {
                requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorTag = cmdletContext.FilterCriteria_CodeVulnerabilityDetectorTag;
            }
            if (requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorTag != null)
            {
                request.FilterCriteria.CodeVulnerabilityDetectorTags = requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorTag;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_CodeVulnerabilityFilePath = null;
            if (cmdletContext.FilterCriteria_CodeVulnerabilityFilePath != null)
            {
                requestFilterCriteria_filterCriteria_CodeVulnerabilityFilePath = cmdletContext.FilterCriteria_CodeVulnerabilityFilePath;
            }
            if (requestFilterCriteria_filterCriteria_CodeVulnerabilityFilePath != null)
            {
                request.FilterCriteria.CodeVulnerabilityFilePath = requestFilterCriteria_filterCriteria_CodeVulnerabilityFilePath;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ComponentId = null;
            if (cmdletContext.FilterCriteria_ComponentId != null)
            {
                requestFilterCriteria_filterCriteria_ComponentId = cmdletContext.FilterCriteria_ComponentId;
            }
            if (requestFilterCriteria_filterCriteria_ComponentId != null)
            {
                request.FilterCriteria.ComponentId = requestFilterCriteria_filterCriteria_ComponentId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ComponentType = null;
            if (cmdletContext.FilterCriteria_ComponentType != null)
            {
                requestFilterCriteria_filterCriteria_ComponentType = cmdletContext.FilterCriteria_ComponentType;
            }
            if (requestFilterCriteria_filterCriteria_ComponentType != null)
            {
                request.FilterCriteria.ComponentType = requestFilterCriteria_filterCriteria_ComponentType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Ec2InstanceImageId = null;
            if (cmdletContext.FilterCriteria_Ec2InstanceImageId != null)
            {
                requestFilterCriteria_filterCriteria_Ec2InstanceImageId = cmdletContext.FilterCriteria_Ec2InstanceImageId;
            }
            if (requestFilterCriteria_filterCriteria_Ec2InstanceImageId != null)
            {
                request.FilterCriteria.Ec2InstanceImageId = requestFilterCriteria_filterCriteria_Ec2InstanceImageId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Ec2InstanceSubnetId = null;
            if (cmdletContext.FilterCriteria_Ec2InstanceSubnetId != null)
            {
                requestFilterCriteria_filterCriteria_Ec2InstanceSubnetId = cmdletContext.FilterCriteria_Ec2InstanceSubnetId;
            }
            if (requestFilterCriteria_filterCriteria_Ec2InstanceSubnetId != null)
            {
                request.FilterCriteria.Ec2InstanceSubnetId = requestFilterCriteria_filterCriteria_Ec2InstanceSubnetId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Ec2InstanceVpcId = null;
            if (cmdletContext.FilterCriteria_Ec2InstanceVpcId != null)
            {
                requestFilterCriteria_filterCriteria_Ec2InstanceVpcId = cmdletContext.FilterCriteria_Ec2InstanceVpcId;
            }
            if (requestFilterCriteria_filterCriteria_Ec2InstanceVpcId != null)
            {
                request.FilterCriteria.Ec2InstanceVpcId = requestFilterCriteria_filterCriteria_Ec2InstanceVpcId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageArchitecture = null;
            if (cmdletContext.FilterCriteria_EcrImageArchitecture != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageArchitecture = cmdletContext.FilterCriteria_EcrImageArchitecture;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageArchitecture != null)
            {
                request.FilterCriteria.EcrImageArchitecture = requestFilterCriteria_filterCriteria_EcrImageArchitecture;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageHash = null;
            if (cmdletContext.FilterCriteria_EcrImageHash != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageHash = cmdletContext.FilterCriteria_EcrImageHash;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageHash != null)
            {
                request.FilterCriteria.EcrImageHash = requestFilterCriteria_filterCriteria_EcrImageHash;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_EcrImagePushedAt = null;
            if (cmdletContext.FilterCriteria_EcrImagePushedAt != null)
            {
                requestFilterCriteria_filterCriteria_EcrImagePushedAt = cmdletContext.FilterCriteria_EcrImagePushedAt;
            }
            if (requestFilterCriteria_filterCriteria_EcrImagePushedAt != null)
            {
                request.FilterCriteria.EcrImagePushedAt = requestFilterCriteria_filterCriteria_EcrImagePushedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageRegistry = null;
            if (cmdletContext.FilterCriteria_EcrImageRegistry != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageRegistry = cmdletContext.FilterCriteria_EcrImageRegistry;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageRegistry != null)
            {
                request.FilterCriteria.EcrImageRegistry = requestFilterCriteria_filterCriteria_EcrImageRegistry;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageRepositoryName = null;
            if (cmdletContext.FilterCriteria_EcrImageRepositoryName != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageRepositoryName = cmdletContext.FilterCriteria_EcrImageRepositoryName;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageRepositoryName != null)
            {
                request.FilterCriteria.EcrImageRepositoryName = requestFilterCriteria_filterCriteria_EcrImageRepositoryName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageTag = null;
            if (cmdletContext.FilterCriteria_EcrImageTag != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageTag = cmdletContext.FilterCriteria_EcrImageTag;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageTag != null)
            {
                request.FilterCriteria.EcrImageTags = requestFilterCriteria_filterCriteria_EcrImageTag;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.NumberFilter> requestFilterCriteria_filterCriteria_EpssScore = null;
            if (cmdletContext.FilterCriteria_EpssScore != null)
            {
                requestFilterCriteria_filterCriteria_EpssScore = cmdletContext.FilterCriteria_EpssScore;
            }
            if (requestFilterCriteria_filterCriteria_EpssScore != null)
            {
                request.FilterCriteria.EpssScore = requestFilterCriteria_filterCriteria_EpssScore;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ExploitAvailable = null;
            if (cmdletContext.FilterCriteria_ExploitAvailable != null)
            {
                requestFilterCriteria_filterCriteria_ExploitAvailable = cmdletContext.FilterCriteria_ExploitAvailable;
            }
            if (requestFilterCriteria_filterCriteria_ExploitAvailable != null)
            {
                request.FilterCriteria.ExploitAvailable = requestFilterCriteria_filterCriteria_ExploitAvailable;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_FindingArn = null;
            if (cmdletContext.FilterCriteria_FindingArn != null)
            {
                requestFilterCriteria_filterCriteria_FindingArn = cmdletContext.FilterCriteria_FindingArn;
            }
            if (requestFilterCriteria_filterCriteria_FindingArn != null)
            {
                request.FilterCriteria.FindingArn = requestFilterCriteria_filterCriteria_FindingArn;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_FindingStatus = null;
            if (cmdletContext.FilterCriteria_FindingStatus != null)
            {
                requestFilterCriteria_filterCriteria_FindingStatus = cmdletContext.FilterCriteria_FindingStatus;
            }
            if (requestFilterCriteria_filterCriteria_FindingStatus != null)
            {
                request.FilterCriteria.FindingStatus = requestFilterCriteria_filterCriteria_FindingStatus;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_FindingType = null;
            if (cmdletContext.FilterCriteria_FindingType != null)
            {
                requestFilterCriteria_filterCriteria_FindingType = cmdletContext.FilterCriteria_FindingType;
            }
            if (requestFilterCriteria_filterCriteria_FindingType != null)
            {
                request.FilterCriteria.FindingType = requestFilterCriteria_filterCriteria_FindingType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_FirstObservedAt = null;
            if (cmdletContext.FilterCriteria_FirstObservedAt != null)
            {
                requestFilterCriteria_filterCriteria_FirstObservedAt = cmdletContext.FilterCriteria_FirstObservedAt;
            }
            if (requestFilterCriteria_filterCriteria_FirstObservedAt != null)
            {
                request.FilterCriteria.FirstObservedAt = requestFilterCriteria_filterCriteria_FirstObservedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_FixAvailable = null;
            if (cmdletContext.FilterCriteria_FixAvailable != null)
            {
                requestFilterCriteria_filterCriteria_FixAvailable = cmdletContext.FilterCriteria_FixAvailable;
            }
            if (requestFilterCriteria_filterCriteria_FixAvailable != null)
            {
                request.FilterCriteria.FixAvailable = requestFilterCriteria_filterCriteria_FixAvailable;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.NumberFilter> requestFilterCriteria_filterCriteria_InspectorScore = null;
            if (cmdletContext.FilterCriteria_InspectorScore != null)
            {
                requestFilterCriteria_filterCriteria_InspectorScore = cmdletContext.FilterCriteria_InspectorScore;
            }
            if (requestFilterCriteria_filterCriteria_InspectorScore != null)
            {
                request.FilterCriteria.InspectorScore = requestFilterCriteria_filterCriteria_InspectorScore;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionExecutionRoleArn = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionExecutionRoleArn != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionExecutionRoleArn = cmdletContext.FilterCriteria_LambdaFunctionExecutionRoleArn;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionExecutionRoleArn != null)
            {
                request.FilterCriteria.LambdaFunctionExecutionRoleArn = requestFilterCriteria_filterCriteria_LambdaFunctionExecutionRoleArn;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_LambdaFunctionLastModifiedAt = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionLastModifiedAt != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionLastModifiedAt = cmdletContext.FilterCriteria_LambdaFunctionLastModifiedAt;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionLastModifiedAt != null)
            {
                request.FilterCriteria.LambdaFunctionLastModifiedAt = requestFilterCriteria_filterCriteria_LambdaFunctionLastModifiedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionLayer = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionLayer != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionLayer = cmdletContext.FilterCriteria_LambdaFunctionLayer;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionLayer != null)
            {
                request.FilterCriteria.LambdaFunctionLayers = requestFilterCriteria_filterCriteria_LambdaFunctionLayer;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionName = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionName != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionName = cmdletContext.FilterCriteria_LambdaFunctionName;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionName != null)
            {
                request.FilterCriteria.LambdaFunctionName = requestFilterCriteria_filterCriteria_LambdaFunctionName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionRuntime = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionRuntime != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionRuntime = cmdletContext.FilterCriteria_LambdaFunctionRuntime;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionRuntime != null)
            {
                request.FilterCriteria.LambdaFunctionRuntime = requestFilterCriteria_filterCriteria_LambdaFunctionRuntime;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_LastObservedAt = null;
            if (cmdletContext.FilterCriteria_LastObservedAt != null)
            {
                requestFilterCriteria_filterCriteria_LastObservedAt = cmdletContext.FilterCriteria_LastObservedAt;
            }
            if (requestFilterCriteria_filterCriteria_LastObservedAt != null)
            {
                request.FilterCriteria.LastObservedAt = requestFilterCriteria_filterCriteria_LastObservedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_NetworkProtocol = null;
            if (cmdletContext.FilterCriteria_NetworkProtocol != null)
            {
                requestFilterCriteria_filterCriteria_NetworkProtocol = cmdletContext.FilterCriteria_NetworkProtocol;
            }
            if (requestFilterCriteria_filterCriteria_NetworkProtocol != null)
            {
                request.FilterCriteria.NetworkProtocol = requestFilterCriteria_filterCriteria_NetworkProtocol;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.PortRangeFilter> requestFilterCriteria_filterCriteria_PortRange = null;
            if (cmdletContext.FilterCriteria_PortRange != null)
            {
                requestFilterCriteria_filterCriteria_PortRange = cmdletContext.FilterCriteria_PortRange;
            }
            if (requestFilterCriteria_filterCriteria_PortRange != null)
            {
                request.FilterCriteria.PortRange = requestFilterCriteria_filterCriteria_PortRange;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_RelatedVulnerability = null;
            if (cmdletContext.FilterCriteria_RelatedVulnerability != null)
            {
                requestFilterCriteria_filterCriteria_RelatedVulnerability = cmdletContext.FilterCriteria_RelatedVulnerability;
            }
            if (requestFilterCriteria_filterCriteria_RelatedVulnerability != null)
            {
                request.FilterCriteria.RelatedVulnerabilities = requestFilterCriteria_filterCriteria_RelatedVulnerability;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ResourceId = null;
            if (cmdletContext.FilterCriteria_ResourceId != null)
            {
                requestFilterCriteria_filterCriteria_ResourceId = cmdletContext.FilterCriteria_ResourceId;
            }
            if (requestFilterCriteria_filterCriteria_ResourceId != null)
            {
                request.FilterCriteria.ResourceId = requestFilterCriteria_filterCriteria_ResourceId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.MapFilter> requestFilterCriteria_filterCriteria_ResourceTag = null;
            if (cmdletContext.FilterCriteria_ResourceTag != null)
            {
                requestFilterCriteria_filterCriteria_ResourceTag = cmdletContext.FilterCriteria_ResourceTag;
            }
            if (requestFilterCriteria_filterCriteria_ResourceTag != null)
            {
                request.FilterCriteria.ResourceTags = requestFilterCriteria_filterCriteria_ResourceTag;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ResourceType = null;
            if (cmdletContext.FilterCriteria_ResourceType != null)
            {
                requestFilterCriteria_filterCriteria_ResourceType = cmdletContext.FilterCriteria_ResourceType;
            }
            if (requestFilterCriteria_filterCriteria_ResourceType != null)
            {
                request.FilterCriteria.ResourceType = requestFilterCriteria_filterCriteria_ResourceType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Severity = null;
            if (cmdletContext.FilterCriteria_Severity != null)
            {
                requestFilterCriteria_filterCriteria_Severity = cmdletContext.FilterCriteria_Severity;
            }
            if (requestFilterCriteria_filterCriteria_Severity != null)
            {
                request.FilterCriteria.Severity = requestFilterCriteria_filterCriteria_Severity;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Title = null;
            if (cmdletContext.FilterCriteria_Title != null)
            {
                requestFilterCriteria_filterCriteria_Title = cmdletContext.FilterCriteria_Title;
            }
            if (requestFilterCriteria_filterCriteria_Title != null)
            {
                request.FilterCriteria.Title = requestFilterCriteria_filterCriteria_Title;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_UpdatedAt = null;
            if (cmdletContext.FilterCriteria_UpdatedAt != null)
            {
                requestFilterCriteria_filterCriteria_UpdatedAt = cmdletContext.FilterCriteria_UpdatedAt;
            }
            if (requestFilterCriteria_filterCriteria_UpdatedAt != null)
            {
                request.FilterCriteria.UpdatedAt = requestFilterCriteria_filterCriteria_UpdatedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_VendorSeverity = null;
            if (cmdletContext.FilterCriteria_VendorSeverity != null)
            {
                requestFilterCriteria_filterCriteria_VendorSeverity = cmdletContext.FilterCriteria_VendorSeverity;
            }
            if (requestFilterCriteria_filterCriteria_VendorSeverity != null)
            {
                request.FilterCriteria.VendorSeverity = requestFilterCriteria_filterCriteria_VendorSeverity;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_VulnerabilityId = null;
            if (cmdletContext.FilterCriteria_VulnerabilityId != null)
            {
                requestFilterCriteria_filterCriteria_VulnerabilityId = cmdletContext.FilterCriteria_VulnerabilityId;
            }
            if (requestFilterCriteria_filterCriteria_VulnerabilityId != null)
            {
                request.FilterCriteria.VulnerabilityId = requestFilterCriteria_filterCriteria_VulnerabilityId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_VulnerabilitySource = null;
            if (cmdletContext.FilterCriteria_VulnerabilitySource != null)
            {
                requestFilterCriteria_filterCriteria_VulnerabilitySource = cmdletContext.FilterCriteria_VulnerabilitySource;
            }
            if (requestFilterCriteria_filterCriteria_VulnerabilitySource != null)
            {
                request.FilterCriteria.VulnerabilitySource = requestFilterCriteria_filterCriteria_VulnerabilitySource;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.PackageFilter> requestFilterCriteria_filterCriteria_VulnerablePackage = null;
            if (cmdletContext.FilterCriteria_VulnerablePackage != null)
            {
                requestFilterCriteria_filterCriteria_VulnerablePackage = cmdletContext.FilterCriteria_VulnerablePackage;
            }
            if (requestFilterCriteria_filterCriteria_VulnerablePackage != null)
            {
                request.FilterCriteria.VulnerablePackages = requestFilterCriteria_filterCriteria_VulnerablePackage;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Reason != null)
            {
                request.Reason = cmdletContext.Reason;
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
        
        private Amazon.Inspector2.Model.UpdateFilterResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.UpdateFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "UpdateFilter");
            try
            {
                #if DESKTOP
                return client.UpdateFilter(request);
                #elif CORECLR
                return client.UpdateFilterAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Inspector2.FilterAction Action { get; set; }
            public System.String Description { get; set; }
            public System.String FilterArn { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_AwsAccountId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_CodeVulnerabilityDetectorName { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_CodeVulnerabilityDetectorTag { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_CodeVulnerabilityFilePath { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ComponentId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ComponentType { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Ec2InstanceImageId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Ec2InstanceSubnetId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Ec2InstanceVpcId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageArchitecture { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageHash { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_EcrImagePushedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageRegistry { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageRepositoryName { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageTag { get; set; }
            public List<Amazon.Inspector2.Model.NumberFilter> FilterCriteria_EpssScore { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ExploitAvailable { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_FindingArn { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_FindingStatus { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_FindingType { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_FirstObservedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_FixAvailable { get; set; }
            public List<Amazon.Inspector2.Model.NumberFilter> FilterCriteria_InspectorScore { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_LambdaFunctionExecutionRoleArn { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_LambdaFunctionLastModifiedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_LambdaFunctionLayer { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_LambdaFunctionName { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_LambdaFunctionRuntime { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_LastObservedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_NetworkProtocol { get; set; }
            public List<Amazon.Inspector2.Model.PortRangeFilter> FilterCriteria_PortRange { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_RelatedVulnerability { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ResourceId { get; set; }
            public List<Amazon.Inspector2.Model.MapFilter> FilterCriteria_ResourceTag { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ResourceType { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Severity { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Title { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_UpdatedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_VendorSeverity { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_VulnerabilityId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_VulnerabilitySource { get; set; }
            public List<Amazon.Inspector2.Model.PackageFilter> FilterCriteria_VulnerablePackage { get; set; }
            public System.String Name { get; set; }
            public System.String Reason { get; set; }
            public System.Func<Amazon.Inspector2.Model.UpdateFilterResponse, UpdateINS2FilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
