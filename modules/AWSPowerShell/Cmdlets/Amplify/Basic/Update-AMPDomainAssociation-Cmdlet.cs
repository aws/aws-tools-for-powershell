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
using Amazon.Amplify;
using Amazon.Amplify.Model;

namespace Amazon.PowerShell.Cmdlets.AMP
{
    /// <summary>
    /// Creates a new domain association for an Amplify app.
    /// </summary>
    [Cmdlet("Update", "AMPDomainAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Amplify.Model.DomainAssociation")]
    [AWSCmdlet("Calls the AWS Amplify UpdateDomainAssociation API operation.", Operation = new[] {"UpdateDomainAssociation"}, SelectReturnType = typeof(Amazon.Amplify.Model.UpdateDomainAssociationResponse))]
    [AWSCmdletOutput("Amazon.Amplify.Model.DomainAssociation or Amazon.Amplify.Model.UpdateDomainAssociationResponse",
        "This cmdlet returns an Amazon.Amplify.Model.DomainAssociation object.",
        "The service call response (type Amazon.Amplify.Model.UpdateDomainAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAMPDomainAssociationCmdlet : AmazonAmplifyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para> The unique ID for an Amplify app. </para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter AutoSubDomainCreationPattern
        /// <summary>
        /// <para>
        /// <para> Sets the branch patterns for automatic subdomain creation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoSubDomainCreationPatterns")]
        public System.String[] AutoSubDomainCreationPattern { get; set; }
        #endregion
        
        #region Parameter AutoSubDomainIAMRole
        /// <summary>
        /// <para>
        /// <para> The required AWS Identity and Access Management (IAM) service role for the Amazon
        /// Resource Name (ARN) for automatically creating subdomains. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoSubDomainIAMRole { get; set; }
        #endregion
        
        #region Parameter CertificateSettings_CustomCertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon resource name (ARN) for the custom certificate that you have already added
        /// to Certificate Manager in your Amazon Web Services account.</para><para>This field is required only when the certificate type is <c>CUSTOM</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateSettings_CustomCertificateArn { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para> The name of the domain. </para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter EnableAutoSubDomain
        /// <summary>
        /// <para>
        /// <para> Enables the automated creation of subdomains for branches. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableAutoSubDomain { get; set; }
        #endregion
        
        #region Parameter SubDomainSetting
        /// <summary>
        /// <para>
        /// <para> Describes the settings for the subdomain. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubDomainSettings")]
        public Amazon.Amplify.Model.SubDomainSetting[] SubDomainSetting { get; set; }
        #endregion
        
        #region Parameter CertificateSettings_Type
        /// <summary>
        /// <para>
        /// <para>The certificate type.</para><para>Specify <c>AMPLIFY_MANAGED</c> to use the default certificate that Amplify provisions
        /// for you.</para><para>Specify <c>CUSTOM</c> to use your own certificate that you have already added to Certificate
        /// Manager in your Amazon Web Services account. Make sure you request (or import) the
        /// certificate in the US East (N. Virginia) Region (us-east-1). For more information
        /// about using ACM, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/import-certificate.html">Importing
        /// certificates into Certificate Manager</a> in the <i>ACM User guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Amplify.CertificateType")]
        public Amazon.Amplify.CertificateType CertificateSettings_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Amplify.Model.UpdateDomainAssociationResponse).
        /// Specifying the name of a property of type Amazon.Amplify.Model.UpdateDomainAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainAssociation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMPDomainAssociation (UpdateDomainAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Amplify.Model.UpdateDomainAssociationResponse, UpdateAMPDomainAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AutoSubDomainCreationPattern != null)
            {
                context.AutoSubDomainCreationPattern = new List<System.String>(this.AutoSubDomainCreationPattern);
            }
            context.AutoSubDomainIAMRole = this.AutoSubDomainIAMRole;
            context.CertificateSettings_CustomCertificateArn = this.CertificateSettings_CustomCertificateArn;
            context.CertificateSettings_Type = this.CertificateSettings_Type;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnableAutoSubDomain = this.EnableAutoSubDomain;
            if (this.SubDomainSetting != null)
            {
                context.SubDomainSetting = new List<Amazon.Amplify.Model.SubDomainSetting>(this.SubDomainSetting);
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
            var request = new Amazon.Amplify.Model.UpdateDomainAssociationRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.AutoSubDomainCreationPattern != null)
            {
                request.AutoSubDomainCreationPatterns = cmdletContext.AutoSubDomainCreationPattern;
            }
            if (cmdletContext.AutoSubDomainIAMRole != null)
            {
                request.AutoSubDomainIAMRole = cmdletContext.AutoSubDomainIAMRole;
            }
            
             // populate CertificateSettings
            var requestCertificateSettingsIsNull = true;
            request.CertificateSettings = new Amazon.Amplify.Model.CertificateSettings();
            System.String requestCertificateSettings_certificateSettings_CustomCertificateArn = null;
            if (cmdletContext.CertificateSettings_CustomCertificateArn != null)
            {
                requestCertificateSettings_certificateSettings_CustomCertificateArn = cmdletContext.CertificateSettings_CustomCertificateArn;
            }
            if (requestCertificateSettings_certificateSettings_CustomCertificateArn != null)
            {
                request.CertificateSettings.CustomCertificateArn = requestCertificateSettings_certificateSettings_CustomCertificateArn;
                requestCertificateSettingsIsNull = false;
            }
            Amazon.Amplify.CertificateType requestCertificateSettings_certificateSettings_Type = null;
            if (cmdletContext.CertificateSettings_Type != null)
            {
                requestCertificateSettings_certificateSettings_Type = cmdletContext.CertificateSettings_Type;
            }
            if (requestCertificateSettings_certificateSettings_Type != null)
            {
                request.CertificateSettings.Type = requestCertificateSettings_certificateSettings_Type;
                requestCertificateSettingsIsNull = false;
            }
             // determine if request.CertificateSettings should be set to null
            if (requestCertificateSettingsIsNull)
            {
                request.CertificateSettings = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.EnableAutoSubDomain != null)
            {
                request.EnableAutoSubDomain = cmdletContext.EnableAutoSubDomain.Value;
            }
            if (cmdletContext.SubDomainSetting != null)
            {
                request.SubDomainSettings = cmdletContext.SubDomainSetting;
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
        
        private Amazon.Amplify.Model.UpdateDomainAssociationResponse CallAWSServiceOperation(IAmazonAmplify client, Amazon.Amplify.Model.UpdateDomainAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify", "UpdateDomainAssociation");
            try
            {
                #if DESKTOP
                return client.UpdateDomainAssociation(request);
                #elif CORECLR
                return client.UpdateDomainAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public List<System.String> AutoSubDomainCreationPattern { get; set; }
            public System.String AutoSubDomainIAMRole { get; set; }
            public System.String CertificateSettings_CustomCertificateArn { get; set; }
            public Amazon.Amplify.CertificateType CertificateSettings_Type { get; set; }
            public System.String DomainName { get; set; }
            public System.Boolean? EnableAutoSubDomain { get; set; }
            public List<Amazon.Amplify.Model.SubDomainSetting> SubDomainSetting { get; set; }
            public System.Func<Amazon.Amplify.Model.UpdateDomainAssociationResponse, UpdateAMPDomainAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainAssociation;
        }
        
    }
}
