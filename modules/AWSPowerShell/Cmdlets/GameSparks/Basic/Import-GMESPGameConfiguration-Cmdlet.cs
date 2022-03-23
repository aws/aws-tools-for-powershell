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
using Amazon.GameSparks;
using Amazon.GameSparks.Model;

namespace Amazon.PowerShell.Cmdlets.GMESP
{
    /// <summary>
    /// Imports a game configuration.
    /// 
    ///  
    /// <para>
    ///  This operation replaces the current configuration of the game with the provided input.
    /// This is not a reversible operation. If you want to preserve the previous configuration,
    /// use <code>CreateSnapshot</code> to make a new snapshot before importing. 
    /// </para>
    /// </summary>
    [Cmdlet("Import", "GMESPGameConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameSparks.Model.GameConfigurationDetails")]
    [AWSCmdlet("Calls the Amazon GameSparks ImportGameConfiguration API operation.", Operation = new[] {"ImportGameConfiguration"}, SelectReturnType = typeof(Amazon.GameSparks.Model.ImportGameConfigurationResponse))]
    [AWSCmdletOutput("Amazon.GameSparks.Model.GameConfigurationDetails or Amazon.GameSparks.Model.ImportGameConfigurationResponse",
        "This cmdlet returns an Amazon.GameSparks.Model.GameConfigurationDetails object.",
        "The service call response (type Amazon.GameSparks.Model.ImportGameConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportGMESPGameConfigurationCmdlet : AmazonGameSparksClientCmdlet, IExecutor
    {
        
        #region Parameter ImportSource_File
        /// <summary>
        /// <para>
        /// <para>The JSON string containing the configuration sections.</para>
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
        public byte[] ImportSource_File { get; set; }
        #endregion
        
        #region Parameter GameName
        /// <summary>
        /// <para>
        /// <para>The name of the game.</para>
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
        public System.String GameName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameSparks.Model.ImportGameConfigurationResponse).
        /// Specifying the name of a property of type Amazon.GameSparks.Model.ImportGameConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GameName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GameName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GameName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-GMESPGameConfiguration (ImportGameConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameSparks.Model.ImportGameConfigurationResponse, ImportGMESPGameConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GameName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GameName = this.GameName;
            #if MODULAR
            if (this.GameName == null && ParameterWasBound(nameof(this.GameName)))
            {
                WriteWarning("You are passing $null as a value for parameter GameName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImportSource_File = this.ImportSource_File;
            #if MODULAR
            if (this.ImportSource_File == null && ParameterWasBound(nameof(this.ImportSource_File)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportSource_File which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _ImportSource_FileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.GameSparks.Model.ImportGameConfigurationRequest();
                
                if (cmdletContext.GameName != null)
                {
                    request.GameName = cmdletContext.GameName;
                }
                
                 // populate ImportSource
                var requestImportSourceIsNull = true;
                request.ImportSource = new Amazon.GameSparks.Model.ImportGameConfigurationSource();
                System.IO.MemoryStream requestImportSource_importSource_File = null;
                if (cmdletContext.ImportSource_File != null)
                {
                    _ImportSource_FileStream = new System.IO.MemoryStream(cmdletContext.ImportSource_File);
                    requestImportSource_importSource_File = _ImportSource_FileStream;
                }
                if (requestImportSource_importSource_File != null)
                {
                    request.ImportSource.File = requestImportSource_importSource_File;
                    requestImportSourceIsNull = false;
                }
                 // determine if request.ImportSource should be set to null
                if (requestImportSourceIsNull)
                {
                    request.ImportSource = null;
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
                if( _ImportSource_FileStream != null)
                {
                    _ImportSource_FileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.GameSparks.Model.ImportGameConfigurationResponse CallAWSServiceOperation(IAmazonGameSparks client, Amazon.GameSparks.Model.ImportGameConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameSparks", "ImportGameConfiguration");
            try
            {
                #if DESKTOP
                return client.ImportGameConfiguration(request);
                #elif CORECLR
                return client.ImportGameConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String GameName { get; set; }
            public byte[] ImportSource_File { get; set; }
            public System.Func<Amazon.GameSparks.Model.ImportGameConfigurationResponse, ImportGMESPGameConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameConfiguration;
        }
        
    }
}
