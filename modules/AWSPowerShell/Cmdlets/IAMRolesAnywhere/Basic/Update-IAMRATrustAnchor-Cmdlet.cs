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
using Amazon.IAMRolesAnywhere;
using Amazon.IAMRolesAnywhere.Model;

namespace Amazon.PowerShell.Cmdlets.IAMRA
{
    /// <summary>
    /// Updates the trust anchor.You establish trust between IAM Roles Anywhere and your certificate
    /// authority (CA) by configuring a trust anchor. A Trust Anchor is defined either as
    /// a reference to a AWS Certificate Manager Private Certificate Authority (ACM PCA),
    /// or by uploading a Certificate Authority (CA) certificate. Your AWS workloads can authenticate
    /// with the trust anchor using certificates issued by the trusted Certificate Authority
    /// (CA) in exchange for temporary AWS credentials.
    /// 
    ///  
    /// <para><b>Required permissions: </b><code>rolesanywhere:UpdateTrustAnchor</code>. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IAMRATrustAnchor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail")]
    [AWSCmdlet("Calls the IAM Roles Anywhere UpdateTrustAnchor API operation.", Operation = new[] {"UpdateTrustAnchor"}, SelectReturnType = typeof(Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorResponse))]
    [AWSCmdletOutput("Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail or Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorResponse",
        "This cmdlet returns an Amazon.IAMRolesAnywhere.Model.TrustAnchorDetail object.",
        "The service call response (type Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIAMRATrustAnchorCmdlet : AmazonIAMRolesAnywhereClientCmdlet, IExecutor
    {
        
        #region Parameter SourceData_AcmPcaArn
        /// <summary>
        /// <para>
        /// <para>The root certificate of the Certificate Manager Private Certificate Authority specified
        /// by this ARN is used in trust validation for <a href="https://docs.aws.amazon.com/rolesanywhere/latest/APIReference/API_CreateSession.html">CreateSession</a>
        /// operations. Included for trust anchors of type <code>AWS_ACM_PCA</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_SourceData_AcmPcaArn")]
        public System.String SourceData_AcmPcaArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the trust anchor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
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
        
        #region Parameter TrustAnchorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the trust anchor.</para>
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
        public System.String TrustAnchorId { get; set; }
        #endregion
        
        #region Parameter SourceData_X509CertificateData
        /// <summary>
        /// <para>
        /// <para>The PEM-encoded data for the certificate anchor. Included for trust anchors of type
        /// <code>CERTIFICATE_BUNDLE</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_SourceData_X509CertificateData")]
        public System.String SourceData_X509CertificateData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrustAnchor'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorResponse).
        /// Specifying the name of a property of type Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrustAnchor";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrustAnchorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrustAnchorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrustAnchorId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrustAnchorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMRATrustAnchor (UpdateTrustAnchor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorResponse, UpdateIAMRATrustAnchorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrustAnchorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            context.SourceData_AcmPcaArn = this.SourceData_AcmPcaArn;
            context.SourceData_X509CertificateData = this.SourceData_X509CertificateData;
            context.Source_SourceType = this.Source_SourceType;
            context.TrustAnchorId = this.TrustAnchorId;
            #if MODULAR
            if (this.TrustAnchorId == null && ParameterWasBound(nameof(this.TrustAnchorId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustAnchorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
            if (cmdletContext.TrustAnchorId != null)
            {
                request.TrustAnchorId = cmdletContext.TrustAnchorId;
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
        
        private Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorResponse CallAWSServiceOperation(IAmazonIAMRolesAnywhere client, Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "IAM Roles Anywhere", "UpdateTrustAnchor");
            try
            {
                #if DESKTOP
                return client.UpdateTrustAnchor(request);
                #elif CORECLR
                return client.UpdateTrustAnchorAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String SourceData_AcmPcaArn { get; set; }
            public System.String SourceData_X509CertificateData { get; set; }
            public Amazon.IAMRolesAnywhere.TrustAnchorType Source_SourceType { get; set; }
            public System.String TrustAnchorId { get; set; }
            public System.Func<Amazon.IAMRolesAnywhere.Model.UpdateTrustAnchorResponse, UpdateIAMRATrustAnchorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrustAnchor;
        }
        
    }
}
