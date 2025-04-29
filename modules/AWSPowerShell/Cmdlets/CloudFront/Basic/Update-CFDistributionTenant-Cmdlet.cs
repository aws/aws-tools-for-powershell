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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Updates a distribution tenant.
    /// </summary>
    [Cmdlet("Update", "CFDistributionTenant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.DistributionTenant")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateDistributionTenant API operation.", Operation = new[] {"UpdateDistributionTenant"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateDistributionTenantResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.DistributionTenant or Amazon.CloudFront.Model.UpdateDistributionTenantResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.DistributionTenant object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateDistributionTenantResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFDistributionTenantCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter WebAcl_Action
        /// <summary>
        /// <para>
        /// <para>The action for the WAF web ACL customization. You can specify <c>override</c> to specify
        /// a separate WAF web ACL for the distribution tenant. If you specify <c>disable</c>,
        /// the distribution tenant won't have WAF web ACL protections and won't inherit from
        /// the multi-tenant distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customizations_WebAcl_Action")]
        [AWSConstantClassSource("Amazon.CloudFront.CustomizationActionType")]
        public Amazon.CloudFront.CustomizationActionType WebAcl_Action { get; set; }
        #endregion
        
        #region Parameter Certificate_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the ACM certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customizations_Certificate_Arn")]
        public System.String Certificate_Arn { get; set; }
        #endregion
        
        #region Parameter WebAcl_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the WAF web ACL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customizations_WebAcl_Arn")]
        public System.String WebAcl_Arn { get; set; }
        #endregion
        
        #region Parameter ManagedCertificateRequest_CertificateTransparencyLoggingPreference
        /// <summary>
        /// <para>
        /// <para>You can opt out of certificate transparency logging by specifying the <c>disabled</c>
        /// option. Opt in by specifying <c>enabled</c>. For more information, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/acm-concepts.html#concept-transparency">Certificate
        /// Transparency Logging </a> in the <i>Certificate Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFront.CertificateTransparencyLoggingPreference")]
        public Amazon.CloudFront.CertificateTransparencyLoggingPreference ManagedCertificateRequest_CertificateTransparencyLoggingPreference { get; set; }
        #endregion
        
        #region Parameter ConnectionGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the target connection group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionGroupId { get; set; }
        #endregion
        
        #region Parameter DistributionId
        /// <summary>
        /// <para>
        /// <para>The ID for the multi-tenant distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DistributionId { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The domains to update for the distribution tenant. A domain object can contain only
        /// a domain property. You must specify at least one domain. Each distribution tenant
        /// can have up to 5 domains.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Domains")]
        public Amazon.CloudFront.Model.DomainItem[] Domain { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the distribution tenant should be updated to an enabled state. If
        /// you update the distribution tenant and it's not enabled, the distribution tenant won't
        /// serve traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the distribution tenant.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The value of the <c>ETag</c> header that you received when retrieving the distribution
        /// tenant to update. This value is returned in the response of the <c>GetDistributionTenant</c>
        /// API operation.</para>
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
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter GeoRestrictions_Location
        /// <summary>
        /// <para>
        /// <para>The locations for geographic restrictions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customizations_GeoRestrictions_Locations")]
        public System.String[] GeoRestrictions_Location { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of parameter values to add to the resource. A parameter is specified as a key-value
        /// pair. A valid parameter value must exist for any parameter that is marked as required
        /// in the multi-tenant distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.CloudFront.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter ManagedCertificateRequest_PrimaryDomainName
        /// <summary>
        /// <para>
        /// <para>The primary domain name associated with the CloudFront managed ACM certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManagedCertificateRequest_PrimaryDomainName { get; set; }
        #endregion
        
        #region Parameter GeoRestrictions_RestrictionType
        /// <summary>
        /// <para>
        /// <para>The method that you want to use to restrict distribution of your content by country:</para><ul><li><para><c>none</c>: No geographic restriction is enabled, meaning access to content is not
        /// restricted by client geo location.</para></li><li><para><c>blacklist</c>: The <c>Location</c> elements specify the countries in which you
        /// don't want CloudFront to distribute your content.</para></li><li><para><c>whitelist</c>: The <c>Location</c> elements specify the countries in which you
        /// want CloudFront to distribute your content.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Customizations_GeoRestrictions_RestrictionType")]
        [AWSConstantClassSource("Amazon.CloudFront.GeoRestrictionType")]
        public Amazon.CloudFront.GeoRestrictionType GeoRestrictions_RestrictionType { get; set; }
        #endregion
        
        #region Parameter ManagedCertificateRequest_ValidationTokenHost
        /// <summary>
        /// <para>
        /// <para>Specify how the HTTP validation token will be served when requesting the CloudFront
        /// managed ACM certificate.</para><ul><li><para>For <c>cloudfront</c>, CloudFront will automatically serve the validation token. Choose
        /// this mode if you can point the domain's DNS to CloudFront immediately.</para></li><li><para>For <c>self-hosted</c>, you serve the validation token from your existing infrastructure.
        /// Choose this mode when you need to maintain current traffic flow while your certificate
        /// is being issued. You can place the validation token at the well-known path on your
        /// existing web server, wait for ACM to validate and issue the certificate, and then
        /// update your DNS to point to CloudFront.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFront.ValidationTokenHost")]
        public Amazon.CloudFront.ValidationTokenHost ManagedCertificateRequest_ValidationTokenHost { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DistributionTenant'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateDistributionTenantResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateDistributionTenantResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DistributionTenant";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFDistributionTenant (UpdateDistributionTenant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateDistributionTenantResponse, UpdateCFDistributionTenantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectionGroupId = this.ConnectionGroupId;
            context.Certificate_Arn = this.Certificate_Arn;
            if (this.GeoRestrictions_Location != null)
            {
                context.GeoRestrictions_Location = new List<System.String>(this.GeoRestrictions_Location);
            }
            context.GeoRestrictions_RestrictionType = this.GeoRestrictions_RestrictionType;
            context.WebAcl_Action = this.WebAcl_Action;
            context.WebAcl_Arn = this.WebAcl_Arn;
            context.DistributionId = this.DistributionId;
            if (this.Domain != null)
            {
                context.Domain = new List<Amazon.CloudFront.Model.DomainItem>(this.Domain);
            }
            context.Enabled = this.Enabled;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            #if MODULAR
            if (this.IfMatch == null && ParameterWasBound(nameof(this.IfMatch)))
            {
                WriteWarning("You are passing $null as a value for parameter IfMatch which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ManagedCertificateRequest_CertificateTransparencyLoggingPreference = this.ManagedCertificateRequest_CertificateTransparencyLoggingPreference;
            context.ManagedCertificateRequest_PrimaryDomainName = this.ManagedCertificateRequest_PrimaryDomainName;
            context.ManagedCertificateRequest_ValidationTokenHost = this.ManagedCertificateRequest_ValidationTokenHost;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.CloudFront.Model.Parameter>(this.Parameter);
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
            var request = new Amazon.CloudFront.Model.UpdateDistributionTenantRequest();
            
            if (cmdletContext.ConnectionGroupId != null)
            {
                request.ConnectionGroupId = cmdletContext.ConnectionGroupId;
            }
            
             // populate Customizations
            var requestCustomizationsIsNull = true;
            request.Customizations = new Amazon.CloudFront.Model.Customizations();
            Amazon.CloudFront.Model.Certificate requestCustomizations_customizations_Certificate = null;
            
             // populate Certificate
            var requestCustomizations_customizations_CertificateIsNull = true;
            requestCustomizations_customizations_Certificate = new Amazon.CloudFront.Model.Certificate();
            System.String requestCustomizations_customizations_Certificate_certificate_Arn = null;
            if (cmdletContext.Certificate_Arn != null)
            {
                requestCustomizations_customizations_Certificate_certificate_Arn = cmdletContext.Certificate_Arn;
            }
            if (requestCustomizations_customizations_Certificate_certificate_Arn != null)
            {
                requestCustomizations_customizations_Certificate.Arn = requestCustomizations_customizations_Certificate_certificate_Arn;
                requestCustomizations_customizations_CertificateIsNull = false;
            }
             // determine if requestCustomizations_customizations_Certificate should be set to null
            if (requestCustomizations_customizations_CertificateIsNull)
            {
                requestCustomizations_customizations_Certificate = null;
            }
            if (requestCustomizations_customizations_Certificate != null)
            {
                request.Customizations.Certificate = requestCustomizations_customizations_Certificate;
                requestCustomizationsIsNull = false;
            }
            Amazon.CloudFront.Model.GeoRestrictionCustomization requestCustomizations_customizations_GeoRestrictions = null;
            
             // populate GeoRestrictions
            var requestCustomizations_customizations_GeoRestrictionsIsNull = true;
            requestCustomizations_customizations_GeoRestrictions = new Amazon.CloudFront.Model.GeoRestrictionCustomization();
            List<System.String> requestCustomizations_customizations_GeoRestrictions_geoRestrictions_Location = null;
            if (cmdletContext.GeoRestrictions_Location != null)
            {
                requestCustomizations_customizations_GeoRestrictions_geoRestrictions_Location = cmdletContext.GeoRestrictions_Location;
            }
            if (requestCustomizations_customizations_GeoRestrictions_geoRestrictions_Location != null)
            {
                requestCustomizations_customizations_GeoRestrictions.Locations = requestCustomizations_customizations_GeoRestrictions_geoRestrictions_Location;
                requestCustomizations_customizations_GeoRestrictionsIsNull = false;
            }
            Amazon.CloudFront.GeoRestrictionType requestCustomizations_customizations_GeoRestrictions_geoRestrictions_RestrictionType = null;
            if (cmdletContext.GeoRestrictions_RestrictionType != null)
            {
                requestCustomizations_customizations_GeoRestrictions_geoRestrictions_RestrictionType = cmdletContext.GeoRestrictions_RestrictionType;
            }
            if (requestCustomizations_customizations_GeoRestrictions_geoRestrictions_RestrictionType != null)
            {
                requestCustomizations_customizations_GeoRestrictions.RestrictionType = requestCustomizations_customizations_GeoRestrictions_geoRestrictions_RestrictionType;
                requestCustomizations_customizations_GeoRestrictionsIsNull = false;
            }
             // determine if requestCustomizations_customizations_GeoRestrictions should be set to null
            if (requestCustomizations_customizations_GeoRestrictionsIsNull)
            {
                requestCustomizations_customizations_GeoRestrictions = null;
            }
            if (requestCustomizations_customizations_GeoRestrictions != null)
            {
                request.Customizations.GeoRestrictions = requestCustomizations_customizations_GeoRestrictions;
                requestCustomizationsIsNull = false;
            }
            Amazon.CloudFront.Model.WebAclCustomization requestCustomizations_customizations_WebAcl = null;
            
             // populate WebAcl
            var requestCustomizations_customizations_WebAclIsNull = true;
            requestCustomizations_customizations_WebAcl = new Amazon.CloudFront.Model.WebAclCustomization();
            Amazon.CloudFront.CustomizationActionType requestCustomizations_customizations_WebAcl_webAcl_Action = null;
            if (cmdletContext.WebAcl_Action != null)
            {
                requestCustomizations_customizations_WebAcl_webAcl_Action = cmdletContext.WebAcl_Action;
            }
            if (requestCustomizations_customizations_WebAcl_webAcl_Action != null)
            {
                requestCustomizations_customizations_WebAcl.Action = requestCustomizations_customizations_WebAcl_webAcl_Action;
                requestCustomizations_customizations_WebAclIsNull = false;
            }
            System.String requestCustomizations_customizations_WebAcl_webAcl_Arn = null;
            if (cmdletContext.WebAcl_Arn != null)
            {
                requestCustomizations_customizations_WebAcl_webAcl_Arn = cmdletContext.WebAcl_Arn;
            }
            if (requestCustomizations_customizations_WebAcl_webAcl_Arn != null)
            {
                requestCustomizations_customizations_WebAcl.Arn = requestCustomizations_customizations_WebAcl_webAcl_Arn;
                requestCustomizations_customizations_WebAclIsNull = false;
            }
             // determine if requestCustomizations_customizations_WebAcl should be set to null
            if (requestCustomizations_customizations_WebAclIsNull)
            {
                requestCustomizations_customizations_WebAcl = null;
            }
            if (requestCustomizations_customizations_WebAcl != null)
            {
                request.Customizations.WebAcl = requestCustomizations_customizations_WebAcl;
                requestCustomizationsIsNull = false;
            }
             // determine if request.Customizations should be set to null
            if (requestCustomizationsIsNull)
            {
                request.Customizations = null;
            }
            if (cmdletContext.DistributionId != null)
            {
                request.DistributionId = cmdletContext.DistributionId;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domains = cmdletContext.Domain;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            
             // populate ManagedCertificateRequest
            var requestManagedCertificateRequestIsNull = true;
            request.ManagedCertificateRequest = new Amazon.CloudFront.Model.ManagedCertificateRequest();
            Amazon.CloudFront.CertificateTransparencyLoggingPreference requestManagedCertificateRequest_managedCertificateRequest_CertificateTransparencyLoggingPreference = null;
            if (cmdletContext.ManagedCertificateRequest_CertificateTransparencyLoggingPreference != null)
            {
                requestManagedCertificateRequest_managedCertificateRequest_CertificateTransparencyLoggingPreference = cmdletContext.ManagedCertificateRequest_CertificateTransparencyLoggingPreference;
            }
            if (requestManagedCertificateRequest_managedCertificateRequest_CertificateTransparencyLoggingPreference != null)
            {
                request.ManagedCertificateRequest.CertificateTransparencyLoggingPreference = requestManagedCertificateRequest_managedCertificateRequest_CertificateTransparencyLoggingPreference;
                requestManagedCertificateRequestIsNull = false;
            }
            System.String requestManagedCertificateRequest_managedCertificateRequest_PrimaryDomainName = null;
            if (cmdletContext.ManagedCertificateRequest_PrimaryDomainName != null)
            {
                requestManagedCertificateRequest_managedCertificateRequest_PrimaryDomainName = cmdletContext.ManagedCertificateRequest_PrimaryDomainName;
            }
            if (requestManagedCertificateRequest_managedCertificateRequest_PrimaryDomainName != null)
            {
                request.ManagedCertificateRequest.PrimaryDomainName = requestManagedCertificateRequest_managedCertificateRequest_PrimaryDomainName;
                requestManagedCertificateRequestIsNull = false;
            }
            Amazon.CloudFront.ValidationTokenHost requestManagedCertificateRequest_managedCertificateRequest_ValidationTokenHost = null;
            if (cmdletContext.ManagedCertificateRequest_ValidationTokenHost != null)
            {
                requestManagedCertificateRequest_managedCertificateRequest_ValidationTokenHost = cmdletContext.ManagedCertificateRequest_ValidationTokenHost;
            }
            if (requestManagedCertificateRequest_managedCertificateRequest_ValidationTokenHost != null)
            {
                request.ManagedCertificateRequest.ValidationTokenHost = requestManagedCertificateRequest_managedCertificateRequest_ValidationTokenHost;
                requestManagedCertificateRequestIsNull = false;
            }
             // determine if request.ManagedCertificateRequest should be set to null
            if (requestManagedCertificateRequestIsNull)
            {
                request.ManagedCertificateRequest = null;
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
        
        private Amazon.CloudFront.Model.UpdateDistributionTenantResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateDistributionTenantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateDistributionTenant");
            try
            {
                return client.UpdateDistributionTenantAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectionGroupId { get; set; }
            public System.String Certificate_Arn { get; set; }
            public List<System.String> GeoRestrictions_Location { get; set; }
            public Amazon.CloudFront.GeoRestrictionType GeoRestrictions_RestrictionType { get; set; }
            public Amazon.CloudFront.CustomizationActionType WebAcl_Action { get; set; }
            public System.String WebAcl_Arn { get; set; }
            public System.String DistributionId { get; set; }
            public List<Amazon.CloudFront.Model.DomainItem> Domain { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public Amazon.CloudFront.CertificateTransparencyLoggingPreference ManagedCertificateRequest_CertificateTransparencyLoggingPreference { get; set; }
            public System.String ManagedCertificateRequest_PrimaryDomainName { get; set; }
            public Amazon.CloudFront.ValidationTokenHost ManagedCertificateRequest_ValidationTokenHost { get; set; }
            public List<Amazon.CloudFront.Model.Parameter> Parameter { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateDistributionTenantResponse, UpdateCFDistributionTenantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DistributionTenant;
        }
        
    }
}
