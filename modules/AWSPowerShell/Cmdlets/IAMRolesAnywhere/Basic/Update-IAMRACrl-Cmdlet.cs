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
    /// Updates the certificate revocation list (CRL). A CRL is a list of certificates that
    /// have been revoked by the issuing certificate authority (CA). IAM Roles Anywhere validates
    /// against the CRL before issuing credentials.
    /// 
    ///  
    /// <para><b>Required permissions: </b><c>rolesanywhere:UpdateCrl</c>. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IAMRACrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IAMRolesAnywhere.Model.CrlDetail")]
    [AWSCmdlet("Calls the IAM Roles Anywhere UpdateCrl API operation.", Operation = new[] {"UpdateCrl"}, SelectReturnType = typeof(Amazon.IAMRolesAnywhere.Model.UpdateCrlResponse))]
    [AWSCmdletOutput("Amazon.IAMRolesAnywhere.Model.CrlDetail or Amazon.IAMRolesAnywhere.Model.UpdateCrlResponse",
        "This cmdlet returns an Amazon.IAMRolesAnywhere.Model.CrlDetail object.",
        "The service call response (type Amazon.IAMRolesAnywhere.Model.UpdateCrlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIAMRACrlCmdlet : AmazonIAMRolesAnywhereClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CrlData
        /// <summary>
        /// <para>
        /// <para>The x509 v3 specified certificate revocation list (CRL).</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] CrlData { get; set; }
        #endregion
        
        #region Parameter CrlId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the certificate revocation list (CRL).</para>
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
        public System.String CrlId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Crl.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Crl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IAMRolesAnywhere.Model.UpdateCrlResponse).
        /// Specifying the name of a property of type Amazon.IAMRolesAnywhere.Model.UpdateCrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Crl";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CrlId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CrlId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CrlId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CrlId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMRACrl (UpdateCrl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IAMRolesAnywhere.Model.UpdateCrlResponse, UpdateIAMRACrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CrlId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CrlData = this.CrlData;
            context.CrlId = this.CrlId;
            #if MODULAR
            if (this.CrlId == null && ParameterWasBound(nameof(this.CrlId)))
            {
                WriteWarning("You are passing $null as a value for parameter CrlId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            
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
                var request = new Amazon.IAMRolesAnywhere.Model.UpdateCrlRequest();
                
                if (cmdletContext.CrlData != null)
                {
                    _CrlDataStream = new System.IO.MemoryStream(cmdletContext.CrlData);
                    request.CrlData = _CrlDataStream;
                }
                if (cmdletContext.CrlId != null)
                {
                    request.CrlId = cmdletContext.CrlId;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
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
        
        private Amazon.IAMRolesAnywhere.Model.UpdateCrlResponse CallAWSServiceOperation(IAmazonIAMRolesAnywhere client, Amazon.IAMRolesAnywhere.Model.UpdateCrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "IAM Roles Anywhere", "UpdateCrl");
            try
            {
                #if DESKTOP
                return client.UpdateCrl(request);
                #elif CORECLR
                return client.UpdateCrlAsync(request).GetAwaiter().GetResult();
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
            public System.String CrlId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.IAMRolesAnywhere.Model.UpdateCrlResponse, UpdateIAMRACrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Crl;
        }
        
    }
}
