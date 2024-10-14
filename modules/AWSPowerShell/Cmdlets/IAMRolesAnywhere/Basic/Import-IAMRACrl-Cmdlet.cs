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
    /// Imports the certificate revocation list (CRL). A CRL is a list of certificates that
    /// have been revoked by the issuing certificate Authority (CA).In order to be properly
    /// imported, a CRL must be in PEM format. IAM Roles Anywhere validates against the CRL
    /// before issuing credentials. 
    /// 
    ///  
    /// <para><b>Required permissions: </b><c>rolesanywhere:ImportCrl</c>. 
    /// </para>
    /// </summary>
    [Cmdlet("Import", "IAMRACrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IAMRolesAnywhere.Model.CrlDetail")]
    [AWSCmdlet("Calls the IAM Roles Anywhere ImportCrl API operation.", Operation = new[] {"ImportCrl"}, SelectReturnType = typeof(Amazon.IAMRolesAnywhere.Model.ImportCrlResponse))]
    [AWSCmdletOutput("Amazon.IAMRolesAnywhere.Model.CrlDetail or Amazon.IAMRolesAnywhere.Model.ImportCrlResponse",
        "This cmdlet returns an Amazon.IAMRolesAnywhere.Model.CrlDetail object.",
        "The service call response (type Amazon.IAMRolesAnywhere.Model.ImportCrlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportIAMRACrlCmdlet : AmazonIAMRolesAnywhereClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CrlData
        /// <summary>
        /// <para>
        /// <para>The x509 v3 specified certificate revocation list (CRL).</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] CrlData { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the certificate revocation list (CRL) is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the certificate revocation list (CRL).</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to attach to the certificate revocation list (CRL).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IAMRolesAnywhere.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrustAnchorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the TrustAnchor the certificate revocation list (CRL) will provide revocation
        /// for.</para>
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
        public System.String TrustAnchorArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Crl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IAMRolesAnywhere.Model.ImportCrlResponse).
        /// Specifying the name of a property of type Amazon.IAMRolesAnywhere.Model.ImportCrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Crl";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-IAMRACrl (ImportCrl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IAMRolesAnywhere.Model.ImportCrlResponse, ImportIAMRACrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CrlData = this.CrlData;
            #if MODULAR
            if (this.CrlData == null && ParameterWasBound(nameof(this.CrlData)))
            {
                WriteWarning("You are passing $null as a value for parameter CrlData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Enabled = this.Enabled;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IAMRolesAnywhere.Model.Tag>(this.Tag);
            }
            context.TrustAnchorArn = this.TrustAnchorArn;
            #if MODULAR
            if (this.TrustAnchorArn == null && ParameterWasBound(nameof(this.TrustAnchorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustAnchorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _CrlDataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.IAMRolesAnywhere.Model.ImportCrlRequest();
                
                if (cmdletContext.CrlData != null)
                {
                    _CrlDataStream = new System.IO.MemoryStream(cmdletContext.CrlData);
                    request.CrlData = _CrlDataStream;
                }
                if (cmdletContext.Enabled != null)
                {
                    request.Enabled = cmdletContext.Enabled.Value;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.Tag != null)
                {
                    request.Tags = cmdletContext.Tag;
                }
                if (cmdletContext.TrustAnchorArn != null)
                {
                    request.TrustAnchorArn = cmdletContext.TrustAnchorArn;
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
            finally
            {
                if( _CrlDataStream != null)
                {
                    _CrlDataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IAMRolesAnywhere.Model.ImportCrlResponse CallAWSServiceOperation(IAmazonIAMRolesAnywhere client, Amazon.IAMRolesAnywhere.Model.ImportCrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "IAM Roles Anywhere", "ImportCrl");
            try
            {
                #if DESKTOP
                return client.ImportCrl(request);
                #elif CORECLR
                return client.ImportCrlAsync(request).GetAwaiter().GetResult();
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
            public byte[] CrlData { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.IAMRolesAnywhere.Model.Tag> Tag { get; set; }
            public System.String TrustAnchorArn { get; set; }
            public System.Func<Amazon.IAMRolesAnywhere.Model.ImportCrlResponse, ImportIAMRACrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Crl;
        }
        
    }
}
