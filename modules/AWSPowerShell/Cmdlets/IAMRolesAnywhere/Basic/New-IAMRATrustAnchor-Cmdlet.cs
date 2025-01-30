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
using Amazon.IAMRolesAnywhere;
using Amazon.IAMRolesAnywhere.Model;

namespace Amazon.PowerShell.Cmdlets.IAMRA
{
    /// <summary>
    /// Creates a trust anchor to establish trust between IAM Roles Anywhere and your certificate
    /// authority (CA). You can define a trust anchor as a reference to an Private Certificate
    /// Authority (Private CA) or by uploading a CA certificate. Your Amazon Web Services
    /// workloads can authenticate with the trust anchor using certificates issued by the
    /// CA in exchange for temporary Amazon Web Services credentials.
    /// 
    ///  
    /// <para><b>Required permissions: </b><c>rolesanywhere:CreateTrustAnchor</c>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "IAMRATrustAnchor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail")]
    [AWSCmdlet("Calls the IAM Roles Anywhere CreateTrustAnchor API operation.", Operation = new[] {"CreateTrustAnchor"}, SelectReturnType = typeof(Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorResponse))]
    [AWSCmdletOutput("Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail or Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorResponse",
        "This cmdlet returns an Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail object.",
        "The service call response (type Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIAMRATrustAnchorCmdlet : AmazonIAMRolesAnywhereClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SourceData_AcmPcaArn
        /// <summary>
        /// <para>
        /// <para> The root certificate of the Private Certificate Authority specified by this ARN is
        /// used in trust validation for temporary credential requests. Included for trust anchors
        /// of type <c>AWS_ACM_PCA</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_SourceData_AcmPcaArn")]
        public System.String SourceData_AcmPcaArn { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the trust anchor is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the trust anchor.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NotificationSetting
        /// <summary>
        /// <para>
        /// <para>A list of notification settings to be associated to the trust anchor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotificationSettings")]
        public Amazon.IAMRolesAnywhere.Model.NotificationSetting[] NotificationSetting { get; set; }
        #endregion
        
        #region Parameter Source_SourceType
        /// <summary>
        /// <para>
        /// <para>The type of the trust anchor. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IAMRolesAnywhere.TrustAnchorType")]
        public Amazon.IAMRolesAnywhere.TrustAnchorType Source_SourceType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to attach to the trust anchor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IAMRolesAnywhere.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter SourceData_X509CertificateData
        /// <summary>
        /// <para>
        /// <para>The PEM-encoded data for the certificate anchor. Included for trust anchors of type
        /// <c>CERTIFICATE_BUNDLE</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_SourceData_X509CertificateData")]
        public System.String SourceData_X509CertificateData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrustAnchor'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorResponse).
        /// Specifying the name of a property of type Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrustAnchor";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMRATrustAnchor (CreateTrustAnchor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorResponse, NewIAMRATrustAnchorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Enabled = this.Enabled;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NotificationSetting != null)
            {
                context.NotificationSetting = new List<Amazon.IAMRolesAnywhere.Model.NotificationSetting>(this.NotificationSetting);
            }
            context.SourceData_AcmPcaArn = this.SourceData_AcmPcaArn;
            context.SourceData_X509CertificateData = this.SourceData_X509CertificateData;
            context.Source_SourceType = this.Source_SourceType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IAMRolesAnywhere.Model.Tag>(this.Tag);
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
            var request = new Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NotificationSetting != null)
            {
                request.NotificationSettings = cmdletContext.NotificationSetting;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.IAMRolesAnywhere.Model.Source();
            Amazon.IAMRolesAnywhere.TrustAnchorType requestSource_source_SourceType = null;
            if (cmdletContext.Source_SourceType != null)
            {
                requestSource_source_SourceType = cmdletContext.Source_SourceType;
            }
            if (requestSource_source_SourceType != null)
            {
                request.Source.SourceType = requestSource_source_SourceType;
                requestSourceIsNull = false;
            }
            Amazon.IAMRolesAnywhere.Model.SourceData requestSource_source_SourceData = null;
            
             // populate SourceData
            var requestSource_source_SourceDataIsNull = true;
            requestSource_source_SourceData = new Amazon.IAMRolesAnywhere.Model.SourceData();
            System.String requestSource_source_SourceData_sourceData_AcmPcaArn = null;
            if (cmdletContext.SourceData_AcmPcaArn != null)
            {
                requestSource_source_SourceData_sourceData_AcmPcaArn = cmdletContext.SourceData_AcmPcaArn;
            }
            if (requestSource_source_SourceData_sourceData_AcmPcaArn != null)
            {
                requestSource_source_SourceData.AcmPcaArn = requestSource_source_SourceData_sourceData_AcmPcaArn;
                requestSource_source_SourceDataIsNull = false;
            }
            System.String requestSource_source_SourceData_sourceData_X509CertificateData = null;
            if (cmdletContext.SourceData_X509CertificateData != null)
            {
                requestSource_source_SourceData_sourceData_X509CertificateData = cmdletContext.SourceData_X509CertificateData;
            }
            if (requestSource_source_SourceData_sourceData_X509CertificateData != null)
            {
                requestSource_source_SourceData.X509CertificateData = requestSource_source_SourceData_sourceData_X509CertificateData;
                requestSource_source_SourceDataIsNull = false;
            }
             // determine if requestSource_source_SourceData should be set to null
            if (requestSource_source_SourceDataIsNull)
            {
                requestSource_source_SourceData = null;
            }
            if (requestSource_source_SourceData != null)
            {
                request.Source.SourceData = requestSource_source_SourceData;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
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
        
        private Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorResponse CallAWSServiceOperation(IAmazonIAMRolesAnywhere client, Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "IAM Roles Anywhere", "CreateTrustAnchor");
            try
            {
                #if DESKTOP
                return client.CreateTrustAnchor(request);
                #elif CORECLR
                return client.CreateTrustAnchorAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enabled { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.IAMRolesAnywhere.Model.NotificationSetting> NotificationSetting { get; set; }
            public System.String SourceData_AcmPcaArn { get; set; }
            public System.String SourceData_X509CertificateData { get; set; }
            public Amazon.IAMRolesAnywhere.TrustAnchorType Source_SourceType { get; set; }
            public List<Amazon.IAMRolesAnywhere.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IAMRolesAnywhere.Model.CreateTrustAnchorResponse, NewIAMRATrustAnchorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrustAnchor;
        }
        
    }
}
