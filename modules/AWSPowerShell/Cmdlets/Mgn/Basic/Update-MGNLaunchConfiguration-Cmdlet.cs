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
using Amazon.Mgn;
using Amazon.Mgn.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Updates multiple LaunchConfigurations by Source Server ID.
    /// 
    ///  <note><para>
    /// bootMode valid values are <c>LEGACY_BIOS | UEFI</c></para></note>
    /// </summary>
    [Cmdlet("Update", "MGNLaunchConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.UpdateLaunchConfigurationResponse")]
    [AWSCmdlet("Calls the Application Migration Service UpdateLaunchConfiguration API operation.", Operation = new[] {"UpdateLaunchConfiguration"}, SelectReturnType = typeof(Amazon.Mgn.Model.UpdateLaunchConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.UpdateLaunchConfigurationResponse",
        "This cmdlet returns an Amazon.Mgn.Model.UpdateLaunchConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateMGNLaunchConfigurationCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountID
        /// <summary>
        /// <para>
        /// <para>Update Launch configuration Account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountID { get; set; }
        #endregion
        
        #region Parameter BootMode
        /// <summary>
        /// <para>
        /// <para>Update Launch configuration boot mode request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.BootMode")]
        public Amazon.Mgn.BootMode BootMode { get; set; }
        #endregion
        
        #region Parameter PostLaunchActions_CloudWatchLogGroupName
        /// <summary>
        /// <para>
        /// <para>AWS Systems Manager Command's CloudWatch log group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostLaunchActions_CloudWatchLogGroupName { get; set; }
        #endregion
        
        #region Parameter CopyPrivateIp
        /// <summary>
        /// <para>
        /// <para>Update Launch configuration copy Private IP request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyPrivateIp { get; set; }
        #endregion
        
        #region Parameter CopyTag
        /// <summary>
        /// <para>
        /// <para>Update Launch configuration copy Tags request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyTags")]
        public System.Boolean? CopyTag { get; set; }
        #endregion
        
        #region Parameter PostLaunchActions_Deployment
        /// <summary>
        /// <para>
        /// <para>Deployment type in which AWS Systems Manager Documents will be executed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.PostLaunchActionsDeploymentType")]
        public Amazon.Mgn.PostLaunchActionsDeploymentType PostLaunchActions_Deployment { get; set; }
        #endregion
        
        #region Parameter EnableMapAutoTagging
        /// <summary>
        /// <para>
        /// <para>Enable map auto tagging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableMapAutoTagging { get; set; }
        #endregion
        
        #region Parameter LaunchDisposition
        /// <summary>
        /// <para>
        /// <para>Update Launch configuration launch disposition request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.LaunchDisposition")]
        public Amazon.Mgn.LaunchDisposition LaunchDisposition { get; set; }
        #endregion
        
        #region Parameter MapAutoTaggingMpeID
        /// <summary>
        /// <para>
        /// <para>Launch configuration map auto tagging MPE ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MapAutoTaggingMpeID { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Update Launch configuration name request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Licensing_OsByol
        /// <summary>
        /// <para>
        /// <para>Configure BYOL OS licensing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Licensing_OsByol { get; set; }
        #endregion
        
        #region Parameter PostLaunchActions_S3LogBucket
        /// <summary>
        /// <para>
        /// <para>AWS Systems Manager Command's logs S3 log bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostLaunchActions_S3LogBucket { get; set; }
        #endregion
        
        #region Parameter PostLaunchActions_S3OutputKeyPrefix
        /// <summary>
        /// <para>
        /// <para>AWS Systems Manager Command's logs S3 output key prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostLaunchActions_S3OutputKeyPrefix { get; set; }
        #endregion
        
        #region Parameter SourceServerID
        /// <summary>
        /// <para>
        /// <para>Update Launch configuration by Source Server ID request.</para>
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
        public System.String SourceServerID { get; set; }
        #endregion
        
        #region Parameter PostLaunchActions_SsmDocument
        /// <summary>
        /// <para>
        /// <para>AWS Systems Manager Documents.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PostLaunchActions_SsmDocuments")]
        public Amazon.Mgn.Model.SsmDocument[] PostLaunchActions_SsmDocument { get; set; }
        #endregion
        
        #region Parameter TargetInstanceTypeRightSizingMethod
        /// <summary>
        /// <para>
        /// <para>Update Launch configuration Target instance right sizing request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.TargetInstanceTypeRightSizingMethod")]
        public Amazon.Mgn.TargetInstanceTypeRightSizingMethod TargetInstanceTypeRightSizingMethod { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.UpdateLaunchConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.UpdateLaunchConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceServerID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGNLaunchConfiguration (UpdateLaunchConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.UpdateLaunchConfigurationResponse, UpdateMGNLaunchConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountID = this.AccountID;
            context.BootMode = this.BootMode;
            context.CopyPrivateIp = this.CopyPrivateIp;
            context.CopyTag = this.CopyTag;
            context.EnableMapAutoTagging = this.EnableMapAutoTagging;
            context.LaunchDisposition = this.LaunchDisposition;
            context.Licensing_OsByol = this.Licensing_OsByol;
            context.MapAutoTaggingMpeID = this.MapAutoTaggingMpeID;
            context.Name = this.Name;
            context.PostLaunchActions_CloudWatchLogGroupName = this.PostLaunchActions_CloudWatchLogGroupName;
            context.PostLaunchActions_Deployment = this.PostLaunchActions_Deployment;
            context.PostLaunchActions_S3LogBucket = this.PostLaunchActions_S3LogBucket;
            context.PostLaunchActions_S3OutputKeyPrefix = this.PostLaunchActions_S3OutputKeyPrefix;
            if (this.PostLaunchActions_SsmDocument != null)
            {
                context.PostLaunchActions_SsmDocument = new List<Amazon.Mgn.Model.SsmDocument>(this.PostLaunchActions_SsmDocument);
            }
            context.SourceServerID = this.SourceServerID;
            #if MODULAR
            if (this.SourceServerID == null && ParameterWasBound(nameof(this.SourceServerID)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceServerID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetInstanceTypeRightSizingMethod = this.TargetInstanceTypeRightSizingMethod;
            
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
            var request = new Amazon.Mgn.Model.UpdateLaunchConfigurationRequest();
            
            if (cmdletContext.AccountID != null)
            {
                request.AccountID = cmdletContext.AccountID;
            }
            if (cmdletContext.BootMode != null)
            {
                request.BootMode = cmdletContext.BootMode;
            }
            if (cmdletContext.CopyPrivateIp != null)
            {
                request.CopyPrivateIp = cmdletContext.CopyPrivateIp.Value;
            }
            if (cmdletContext.CopyTag != null)
            {
                request.CopyTags = cmdletContext.CopyTag.Value;
            }
            if (cmdletContext.EnableMapAutoTagging != null)
            {
                request.EnableMapAutoTagging = cmdletContext.EnableMapAutoTagging.Value;
            }
            if (cmdletContext.LaunchDisposition != null)
            {
                request.LaunchDisposition = cmdletContext.LaunchDisposition;
            }
            
             // populate Licensing
            var requestLicensingIsNull = true;
            request.Licensing = new Amazon.Mgn.Model.Licensing();
            System.Boolean? requestLicensing_licensing_OsByol = null;
            if (cmdletContext.Licensing_OsByol != null)
            {
                requestLicensing_licensing_OsByol = cmdletContext.Licensing_OsByol.Value;
            }
            if (requestLicensing_licensing_OsByol != null)
            {
                request.Licensing.OsByol = requestLicensing_licensing_OsByol.Value;
                requestLicensingIsNull = false;
            }
             // determine if request.Licensing should be set to null
            if (requestLicensingIsNull)
            {
                request.Licensing = null;
            }
            if (cmdletContext.MapAutoTaggingMpeID != null)
            {
                request.MapAutoTaggingMpeID = cmdletContext.MapAutoTaggingMpeID;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate PostLaunchActions
            var requestPostLaunchActionsIsNull = true;
            request.PostLaunchActions = new Amazon.Mgn.Model.PostLaunchActions();
            System.String requestPostLaunchActions_postLaunchActions_CloudWatchLogGroupName = null;
            if (cmdletContext.PostLaunchActions_CloudWatchLogGroupName != null)
            {
                requestPostLaunchActions_postLaunchActions_CloudWatchLogGroupName = cmdletContext.PostLaunchActions_CloudWatchLogGroupName;
            }
            if (requestPostLaunchActions_postLaunchActions_CloudWatchLogGroupName != null)
            {
                request.PostLaunchActions.CloudWatchLogGroupName = requestPostLaunchActions_postLaunchActions_CloudWatchLogGroupName;
                requestPostLaunchActionsIsNull = false;
            }
            Amazon.Mgn.PostLaunchActionsDeploymentType requestPostLaunchActions_postLaunchActions_Deployment = null;
            if (cmdletContext.PostLaunchActions_Deployment != null)
            {
                requestPostLaunchActions_postLaunchActions_Deployment = cmdletContext.PostLaunchActions_Deployment;
            }
            if (requestPostLaunchActions_postLaunchActions_Deployment != null)
            {
                request.PostLaunchActions.Deployment = requestPostLaunchActions_postLaunchActions_Deployment;
                requestPostLaunchActionsIsNull = false;
            }
            System.String requestPostLaunchActions_postLaunchActions_S3LogBucket = null;
            if (cmdletContext.PostLaunchActions_S3LogBucket != null)
            {
                requestPostLaunchActions_postLaunchActions_S3LogBucket = cmdletContext.PostLaunchActions_S3LogBucket;
            }
            if (requestPostLaunchActions_postLaunchActions_S3LogBucket != null)
            {
                request.PostLaunchActions.S3LogBucket = requestPostLaunchActions_postLaunchActions_S3LogBucket;
                requestPostLaunchActionsIsNull = false;
            }
            System.String requestPostLaunchActions_postLaunchActions_S3OutputKeyPrefix = null;
            if (cmdletContext.PostLaunchActions_S3OutputKeyPrefix != null)
            {
                requestPostLaunchActions_postLaunchActions_S3OutputKeyPrefix = cmdletContext.PostLaunchActions_S3OutputKeyPrefix;
            }
            if (requestPostLaunchActions_postLaunchActions_S3OutputKeyPrefix != null)
            {
                request.PostLaunchActions.S3OutputKeyPrefix = requestPostLaunchActions_postLaunchActions_S3OutputKeyPrefix;
                requestPostLaunchActionsIsNull = false;
            }
            List<Amazon.Mgn.Model.SsmDocument> requestPostLaunchActions_postLaunchActions_SsmDocument = null;
            if (cmdletContext.PostLaunchActions_SsmDocument != null)
            {
                requestPostLaunchActions_postLaunchActions_SsmDocument = cmdletContext.PostLaunchActions_SsmDocument;
            }
            if (requestPostLaunchActions_postLaunchActions_SsmDocument != null)
            {
                request.PostLaunchActions.SsmDocuments = requestPostLaunchActions_postLaunchActions_SsmDocument;
                requestPostLaunchActionsIsNull = false;
            }
             // determine if request.PostLaunchActions should be set to null
            if (requestPostLaunchActionsIsNull)
            {
                request.PostLaunchActions = null;
            }
            if (cmdletContext.SourceServerID != null)
            {
                request.SourceServerID = cmdletContext.SourceServerID;
            }
            if (cmdletContext.TargetInstanceTypeRightSizingMethod != null)
            {
                request.TargetInstanceTypeRightSizingMethod = cmdletContext.TargetInstanceTypeRightSizingMethod;
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
        
        private Amazon.Mgn.Model.UpdateLaunchConfigurationResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.UpdateLaunchConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "UpdateLaunchConfiguration");
            try
            {
                return client.UpdateLaunchConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountID { get; set; }
            public Amazon.Mgn.BootMode BootMode { get; set; }
            public System.Boolean? CopyPrivateIp { get; set; }
            public System.Boolean? CopyTag { get; set; }
            public System.Boolean? EnableMapAutoTagging { get; set; }
            public Amazon.Mgn.LaunchDisposition LaunchDisposition { get; set; }
            public System.Boolean? Licensing_OsByol { get; set; }
            public System.String MapAutoTaggingMpeID { get; set; }
            public System.String Name { get; set; }
            public System.String PostLaunchActions_CloudWatchLogGroupName { get; set; }
            public Amazon.Mgn.PostLaunchActionsDeploymentType PostLaunchActions_Deployment { get; set; }
            public System.String PostLaunchActions_S3LogBucket { get; set; }
            public System.String PostLaunchActions_S3OutputKeyPrefix { get; set; }
            public List<Amazon.Mgn.Model.SsmDocument> PostLaunchActions_SsmDocument { get; set; }
            public System.String SourceServerID { get; set; }
            public Amazon.Mgn.TargetInstanceTypeRightSizingMethod TargetInstanceTypeRightSizingMethod { get; set; }
            public System.Func<Amazon.Mgn.Model.UpdateLaunchConfigurationResponse, UpdateMGNLaunchConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
