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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Imports the installation media for an on-premises, bring your own media (BYOM) DB
    /// engine, such as SQL Server.
    /// </summary>
    [Cmdlet("Import", "RDSInstallationMedia", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.ImportInstallationMediaResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ImportInstallationMedia API operation.", Operation = new[] {"ImportInstallationMedia"}, SelectReturnType = typeof(Amazon.RDS.Model.ImportInstallationMediaResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.ImportInstallationMediaResponse",
        "This cmdlet returns an Amazon.RDS.Model.ImportInstallationMediaResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportRDSInstallationMediaCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter CustomAvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The identifier of the custom Availability Zone (AZ) to import the installation media
        /// to.</para>
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
        public System.String CustomAvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the database engine to be used for this instance. </para><para>The list only includes supported on-premises, bring your own media (BYOM) DB engines.
        /// </para><para>Valid Values: </para><ul><li><para><code>sqlserver-ee</code></para></li><li><para><code>sqlserver-se</code></para></li><li><para><code>sqlserver-ex</code></para></li><li><para><code>sqlserver-web</code></para></li></ul>
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
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineInstallationMediaPath
        /// <summary>
        /// <para>
        /// <para>The path to the installation media for the specified DB engine.</para><para>Example: <code>SQLServerISO/en_sql_server_2016_enterprise_x64_dvd_8701793.iso</code></para>
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
        public System.String EngineInstallationMediaPath { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to use.</para><para>For a list of valid engine versions, call <a>DescribeDBEngineVersions</a>.</para><para>The following are the database engines and links to information about the major and
        /// minor versions. The list only includes supported on-premises, bring your own media
        /// (BYOM) DB engines.</para><para><b>Microsoft SQL Server</b></para><para>See <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_SQLServer.html#SQLServer.Concepts.General.FeatureSupport">Version
        /// and Feature Support on Amazon RDS</a> in the <i>Amazon RDS User Guide.</i></para>
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
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter OSInstallationMediaPath
        /// <summary>
        /// <para>
        /// <para>The path to the installation media for the operating system associated with the specified
        /// DB engine.</para><para>Example: <code>WindowsISO/en_windows_server_2016_x64_dvd_9327751.iso</code></para>
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
        public System.String OSInstallationMediaPath { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ImportInstallationMediaResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ImportInstallationMediaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomAvailabilityZoneId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomAvailabilityZoneId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomAvailabilityZoneId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomAvailabilityZoneId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-RDSInstallationMedia (ImportInstallationMedia)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ImportInstallationMediaResponse, ImportRDSInstallationMediaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomAvailabilityZoneId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomAvailabilityZoneId = this.CustomAvailabilityZoneId;
            #if MODULAR
            if (this.CustomAvailabilityZoneId == null && ParameterWasBound(nameof(this.CustomAvailabilityZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomAvailabilityZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineInstallationMediaPath = this.EngineInstallationMediaPath;
            #if MODULAR
            if (this.EngineInstallationMediaPath == null && ParameterWasBound(nameof(this.EngineInstallationMediaPath)))
            {
                WriteWarning("You are passing $null as a value for parameter EngineInstallationMediaPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineVersion = this.EngineVersion;
            #if MODULAR
            if (this.EngineVersion == null && ParameterWasBound(nameof(this.EngineVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter EngineVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OSInstallationMediaPath = this.OSInstallationMediaPath;
            #if MODULAR
            if (this.OSInstallationMediaPath == null && ParameterWasBound(nameof(this.OSInstallationMediaPath)))
            {
                WriteWarning("You are passing $null as a value for parameter OSInstallationMediaPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.ImportInstallationMediaRequest();
            
            if (cmdletContext.CustomAvailabilityZoneId != null)
            {
                request.CustomAvailabilityZoneId = cmdletContext.CustomAvailabilityZoneId;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineInstallationMediaPath != null)
            {
                request.EngineInstallationMediaPath = cmdletContext.EngineInstallationMediaPath;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.OSInstallationMediaPath != null)
            {
                request.OSInstallationMediaPath = cmdletContext.OSInstallationMediaPath;
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
        
        private Amazon.RDS.Model.ImportInstallationMediaResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ImportInstallationMediaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ImportInstallationMedia");
            try
            {
                #if DESKTOP
                return client.ImportInstallationMedia(request);
                #elif CORECLR
                return client.ImportInstallationMediaAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomAvailabilityZoneId { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineInstallationMediaPath { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String OSInstallationMediaPath { get; set; }
            public System.Func<Amazon.RDS.Model.ImportInstallationMediaResponse, ImportRDSInstallationMediaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
