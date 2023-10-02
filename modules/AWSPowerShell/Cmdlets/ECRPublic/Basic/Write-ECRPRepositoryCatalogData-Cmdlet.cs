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
using Amazon.ECRPublic;
using Amazon.ECRPublic.Model;

namespace Amazon.PowerShell.Cmdlets.ECRP
{
    /// <summary>
    /// Creates or updates the catalog data for a repository in a public registry.
    /// </summary>
    [Cmdlet("Write", "ECRPRepositoryCatalogData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECRPublic.Model.RepositoryCatalogData")]
    [AWSCmdlet("Calls the Amazon Elastic Container Registry Public PutRepositoryCatalogData API operation.", Operation = new[] {"PutRepositoryCatalogData"}, SelectReturnType = typeof(Amazon.ECRPublic.Model.PutRepositoryCatalogDataResponse))]
    [AWSCmdletOutput("Amazon.ECRPublic.Model.RepositoryCatalogData or Amazon.ECRPublic.Model.PutRepositoryCatalogDataResponse",
        "This cmdlet returns an Amazon.ECRPublic.Model.RepositoryCatalogData object.",
        "The service call response (type Amazon.ECRPublic.Model.PutRepositoryCatalogDataResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteECRPRepositoryCatalogDataCmdlet : AmazonECRPublicClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogData_AboutText
        /// <summary>
        /// <para>
        /// <para>A detailed description of the contents of the repository. It's publicly visible in
        /// the Amazon ECR Public Gallery. The text must be in markdown format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogData_AboutText { get; set; }
        #endregion
        
        #region Parameter CatalogData_Architecture
        /// <summary>
        /// <para>
        /// <para>The system architecture that the images in the repository are compatible with. On
        /// the Amazon ECR Public Gallery, the following supported architectures appear as badges
        /// on the repository and are used as search filters.</para><note><para>If an unsupported tag is added to your repository catalog data, it's associated with
        /// the repository and can be retrieved using the API but isn't discoverable in the Amazon
        /// ECR Public Gallery.</para></note><ul><li><para><code>ARM</code></para></li><li><para><code>ARM 64</code></para></li><li><para><code>x86</code></para></li><li><para><code>x86-64</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogData_Architectures")]
        public System.String[] CatalogData_Architecture { get; set; }
        #endregion
        
        #region Parameter CatalogData_Description
        /// <summary>
        /// <para>
        /// <para>A short description of the contents of the repository. This text appears in both the
        /// image details and also when searching for repositories on the Amazon ECR Public Gallery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogData_Description { get; set; }
        #endregion
        
        #region Parameter CatalogData_LogoImageBlob
        /// <summary>
        /// <para>
        /// <para>The base64-encoded repository logo payload.</para><note><para>The repository logo is only publicly visible in the Amazon ECR Public Gallery for
        /// verified accounts.</para></note>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] CatalogData_LogoImageBlob { get; set; }
        #endregion
        
        #region Parameter CatalogData_OperatingSystem
        /// <summary>
        /// <para>
        /// <para>The operating systems that the images in the repository are compatible with. On the
        /// Amazon ECR Public Gallery, the following supported operating systems appear as badges
        /// on the repository and are used as search filters.</para><note><para>If an unsupported tag is added to your repository catalog data, it's associated with
        /// the repository and can be retrieved using the API but isn't discoverable in the Amazon
        /// ECR Public Gallery.</para></note><ul><li><para><code>Linux</code></para></li><li><para><code>Windows</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CatalogData_OperatingSystems")]
        public System.String[] CatalogData_OperatingSystem { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that's associated with the public registry the
        /// repository is in. If you do not specify a registry, the default public registry is
        /// assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository to create or update the catalog data for.</para>
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
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter CatalogData_UsageText
        /// <summary>
        /// <para>
        /// <para>Detailed information about how to use the contents of the repository. It's publicly
        /// visible in the Amazon ECR Public Gallery. The usage text provides context, support
        /// information, and additional usage details for users of the repository. The text must
        /// be in markdown format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogData_UsageText { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CatalogData'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECRPublic.Model.PutRepositoryCatalogDataResponse).
        /// Specifying the name of a property of type Amazon.ECRPublic.Model.PutRepositoryCatalogDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CatalogData";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RepositoryName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RepositoryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ECRPRepositoryCatalogData (PutRepositoryCatalogData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECRPublic.Model.PutRepositoryCatalogDataResponse, WriteECRPRepositoryCatalogDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RepositoryName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogData_AboutText = this.CatalogData_AboutText;
            if (this.CatalogData_Architecture != null)
            {
                context.CatalogData_Architecture = new List<System.String>(this.CatalogData_Architecture);
            }
            context.CatalogData_Description = this.CatalogData_Description;
            context.CatalogData_LogoImageBlob = this.CatalogData_LogoImageBlob;
            if (this.CatalogData_OperatingSystem != null)
            {
                context.CatalogData_OperatingSystem = new List<System.String>(this.CatalogData_OperatingSystem);
            }
            context.CatalogData_UsageText = this.CatalogData_UsageText;
            context.RegistryId = this.RegistryId;
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _CatalogData_LogoImageBlobStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.ECRPublic.Model.PutRepositoryCatalogDataRequest();
                
                
                 // populate CatalogData
                var requestCatalogDataIsNull = true;
                request.CatalogData = new Amazon.ECRPublic.Model.RepositoryCatalogDataInput();
                System.String requestCatalogData_catalogData_AboutText = null;
                if (cmdletContext.CatalogData_AboutText != null)
                {
                    requestCatalogData_catalogData_AboutText = cmdletContext.CatalogData_AboutText;
                }
                if (requestCatalogData_catalogData_AboutText != null)
                {
                    request.CatalogData.AboutText = requestCatalogData_catalogData_AboutText;
                    requestCatalogDataIsNull = false;
                }
                List<System.String> requestCatalogData_catalogData_Architecture = null;
                if (cmdletContext.CatalogData_Architecture != null)
                {
                    requestCatalogData_catalogData_Architecture = cmdletContext.CatalogData_Architecture;
                }
                if (requestCatalogData_catalogData_Architecture != null)
                {
                    request.CatalogData.Architectures = requestCatalogData_catalogData_Architecture;
                    requestCatalogDataIsNull = false;
                }
                System.String requestCatalogData_catalogData_Description = null;
                if (cmdletContext.CatalogData_Description != null)
                {
                    requestCatalogData_catalogData_Description = cmdletContext.CatalogData_Description;
                }
                if (requestCatalogData_catalogData_Description != null)
                {
                    request.CatalogData.Description = requestCatalogData_catalogData_Description;
                    requestCatalogDataIsNull = false;
                }
                System.IO.MemoryStream requestCatalogData_catalogData_LogoImageBlob = null;
                if (cmdletContext.CatalogData_LogoImageBlob != null)
                {
                    _CatalogData_LogoImageBlobStream = new System.IO.MemoryStream(cmdletContext.CatalogData_LogoImageBlob);
                    requestCatalogData_catalogData_LogoImageBlob = _CatalogData_LogoImageBlobStream;
                }
                if (requestCatalogData_catalogData_LogoImageBlob != null)
                {
                    request.CatalogData.LogoImageBlob = requestCatalogData_catalogData_LogoImageBlob;
                    requestCatalogDataIsNull = false;
                }
                List<System.String> requestCatalogData_catalogData_OperatingSystem = null;
                if (cmdletContext.CatalogData_OperatingSystem != null)
                {
                    requestCatalogData_catalogData_OperatingSystem = cmdletContext.CatalogData_OperatingSystem;
                }
                if (requestCatalogData_catalogData_OperatingSystem != null)
                {
                    request.CatalogData.OperatingSystems = requestCatalogData_catalogData_OperatingSystem;
                    requestCatalogDataIsNull = false;
                }
                System.String requestCatalogData_catalogData_UsageText = null;
                if (cmdletContext.CatalogData_UsageText != null)
                {
                    requestCatalogData_catalogData_UsageText = cmdletContext.CatalogData_UsageText;
                }
                if (requestCatalogData_catalogData_UsageText != null)
                {
                    request.CatalogData.UsageText = requestCatalogData_catalogData_UsageText;
                    requestCatalogDataIsNull = false;
                }
                 // determine if request.CatalogData should be set to null
                if (requestCatalogDataIsNull)
                {
                    request.CatalogData = null;
                }
                if (cmdletContext.RegistryId != null)
                {
                    request.RegistryId = cmdletContext.RegistryId;
                }
                if (cmdletContext.RepositoryName != null)
                {
                    request.RepositoryName = cmdletContext.RepositoryName;
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
                if( _CatalogData_LogoImageBlobStream != null)
                {
                    _CatalogData_LogoImageBlobStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ECRPublic.Model.PutRepositoryCatalogDataResponse CallAWSServiceOperation(IAmazonECRPublic client, Amazon.ECRPublic.Model.PutRepositoryCatalogDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Registry Public", "PutRepositoryCatalogData");
            try
            {
                #if DESKTOP
                return client.PutRepositoryCatalogData(request);
                #elif CORECLR
                return client.PutRepositoryCatalogDataAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogData_AboutText { get; set; }
            public List<System.String> CatalogData_Architecture { get; set; }
            public System.String CatalogData_Description { get; set; }
            public byte[] CatalogData_LogoImageBlob { get; set; }
            public List<System.String> CatalogData_OperatingSystem { get; set; }
            public System.String CatalogData_UsageText { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.Func<Amazon.ECRPublic.Model.PutRepositoryCatalogDataResponse, WriteECRPRepositoryCatalogDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CatalogData;
        }
        
    }
}
