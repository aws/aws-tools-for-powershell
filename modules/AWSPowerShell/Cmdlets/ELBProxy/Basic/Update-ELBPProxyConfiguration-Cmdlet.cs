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
using Amazon.ELBProxy;
using Amazon.ELBProxy.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ELBP
{
    /// <summary>
    /// Updates the configuration for the specified proxy. You can update the configuration
    /// file, the configuration archive, or both.
    /// </summary>
    [Cmdlet("Update", "ELBPProxyConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ELBProxy.Model.UpdateProxyConfigurationResponse")]
    [AWSCmdlet("Calls the Elastic Load Balancing for Envoy UpdateProxyConfiguration API operation.", Operation = new[] {"UpdateProxyConfiguration"}, SelectReturnType = typeof(Amazon.ELBProxy.Model.UpdateProxyConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ELBProxy.Model.UpdateProxyConfigurationResponse",
        "This cmdlet returns an Amazon.ELBProxy.Model.UpdateProxyConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateELBPProxyConfigurationCmdlet : AmazonELBProxyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationArchive_ConfigurationByte
        /// <summary>
        /// <para>
        /// The contents of the configuration archive.
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationArchive_ConfigurationBytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] ConfigurationArchive_ConfigurationByte { get; set; }
        #endregion
        
        #region Parameter ConfigurationFile_ConfigurationByte
        /// <summary>
        /// <para>
        /// The contents of the configuration file.
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationFile_ConfigurationBytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] ConfigurationFile_ConfigurationByte { get; set; }
        #endregion
        
        #region Parameter CustomerKmsKeyArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the
        /// customer managed KMS key used to encrypt the proxy's configuration content. Specify
        /// a new ARN to set or rotate the key. If you don't specify a value, the existing key
        /// is unchanged.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerKmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ProxyIdentifier
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the
        /// proxy.
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
        public System.String ProxyIdentifier { get; set; }
        #endregion
        
        #region Parameter ResetConfigurationArchive
        /// <summary>
        /// <para>
        /// Indicates whether to remove
        /// the configuration archive from the proxy.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ResetConfigurationArchive { get; set; }
        #endregion
        
        #region Parameter ResetCustomerKmsKeyArn
        /// <summary>
        /// <para>
        /// Indicates whether to remove the
        /// customer managed KMS key from the proxy and use the default service-owned key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ResetCustomerKmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ELBProxy.Model.UpdateProxyConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ELBProxy.Model.UpdateProxyConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProxyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ELBPProxyConfiguration (UpdateProxyConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ELBProxy.Model.UpdateProxyConfigurationResponse, UpdateELBPProxyConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationArchive_ConfigurationByte = this.ConfigurationArchive_ConfigurationByte;
            context.ConfigurationFile_ConfigurationByte = this.ConfigurationFile_ConfigurationByte;
            context.CustomerKmsKeyArn = this.CustomerKmsKeyArn;
            context.ProxyIdentifier = this.ProxyIdentifier;
            #if MODULAR
            if (this.ProxyIdentifier == null && ParameterWasBound(nameof(this.ProxyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ProxyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResetConfigurationArchive = this.ResetConfigurationArchive;
            context.ResetCustomerKmsKeyArn = this.ResetCustomerKmsKeyArn;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _ConfigurationArchive_ConfigurationByteStream = null;
            System.IO.MemoryStream _ConfigurationFile_ConfigurationByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.ELBProxy.Model.UpdateProxyConfigurationRequest();
                
                
                 // populate ConfigurationArchive
                var requestConfigurationArchiveIsNull = true;
                request.ConfigurationArchive = new Amazon.ELBProxy.Model.ConfigurationArchive();
                System.IO.MemoryStream requestConfigurationArchive_configurationArchive_ConfigurationByte = null;
                if (cmdletContext.ConfigurationArchive_ConfigurationByte != null)
                {
                    _ConfigurationArchive_ConfigurationByteStream = new System.IO.MemoryStream(cmdletContext.ConfigurationArchive_ConfigurationByte);
                    requestConfigurationArchive_configurationArchive_ConfigurationByte = _ConfigurationArchive_ConfigurationByteStream;
                }
                if (requestConfigurationArchive_configurationArchive_ConfigurationByte != null)
                {
                    request.ConfigurationArchive.ConfigurationBytes = requestConfigurationArchive_configurationArchive_ConfigurationByte;
                    requestConfigurationArchiveIsNull = false;
                }
                 // determine if request.ConfigurationArchive should be set to null
                if (requestConfigurationArchiveIsNull)
                {
                    request.ConfigurationArchive = null;
                }
                
                 // populate ConfigurationFile
                var requestConfigurationFileIsNull = true;
                request.ConfigurationFile = new Amazon.ELBProxy.Model.ConfigurationFile();
                System.IO.MemoryStream requestConfigurationFile_configurationFile_ConfigurationByte = null;
                if (cmdletContext.ConfigurationFile_ConfigurationByte != null)
                {
                    _ConfigurationFile_ConfigurationByteStream = new System.IO.MemoryStream(cmdletContext.ConfigurationFile_ConfigurationByte);
                    requestConfigurationFile_configurationFile_ConfigurationByte = _ConfigurationFile_ConfigurationByteStream;
                }
                if (requestConfigurationFile_configurationFile_ConfigurationByte != null)
                {
                    request.ConfigurationFile.ConfigurationBytes = requestConfigurationFile_configurationFile_ConfigurationByte;
                    requestConfigurationFileIsNull = false;
                }
                 // determine if request.ConfigurationFile should be set to null
                if (requestConfigurationFileIsNull)
                {
                    request.ConfigurationFile = null;
                }
                if (cmdletContext.CustomerKmsKeyArn != null)
                {
                    request.CustomerKmsKeyArn = cmdletContext.CustomerKmsKeyArn;
                }
                if (cmdletContext.ProxyIdentifier != null)
                {
                    request.ProxyIdentifier = cmdletContext.ProxyIdentifier;
                }
                if (cmdletContext.ResetConfigurationArchive != null)
                {
                    request.ResetConfigurationArchive = cmdletContext.ResetConfigurationArchive.Value;
                }
                if (cmdletContext.ResetCustomerKmsKeyArn != null)
                {
                    request.ResetCustomerKmsKeyArn = cmdletContext.ResetCustomerKmsKeyArn.Value;
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
                if( _ConfigurationArchive_ConfigurationByteStream != null)
                {
                    _ConfigurationArchive_ConfigurationByteStream.Dispose();
                }
                if( _ConfigurationFile_ConfigurationByteStream != null)
                {
                    _ConfigurationFile_ConfigurationByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ELBProxy.Model.UpdateProxyConfigurationResponse CallAWSServiceOperation(IAmazonELBProxy client, Amazon.ELBProxy.Model.UpdateProxyConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing for Envoy", "UpdateProxyConfiguration");
            try
            {
                return client.UpdateProxyConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] ConfigurationArchive_ConfigurationByte { get; set; }
            public byte[] ConfigurationFile_ConfigurationByte { get; set; }
            public System.String CustomerKmsKeyArn { get; set; }
            public System.String ProxyIdentifier { get; set; }
            public System.Boolean? ResetConfigurationArchive { get; set; }
            public System.Boolean? ResetCustomerKmsKeyArn { get; set; }
            public System.Func<Amazon.ELBProxy.Model.UpdateProxyConfigurationResponse, UpdateELBPProxyConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
