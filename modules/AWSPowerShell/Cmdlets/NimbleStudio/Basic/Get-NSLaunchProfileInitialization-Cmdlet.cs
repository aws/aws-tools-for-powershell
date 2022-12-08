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
using Amazon.NimbleStudio;
using Amazon.NimbleStudio.Model;

namespace Amazon.PowerShell.Cmdlets.NS
{
    /// <summary>
    /// Get a launch profile initialization.
    /// </summary>
    [Cmdlet("Get", "NSLaunchProfileInitialization")]
    [OutputType("Amazon.NimbleStudio.Model.LaunchProfileInitialization")]
    [AWSCmdlet("Calls the Amazon Nimble Studio GetLaunchProfileInitialization API operation.", Operation = new[] {"GetLaunchProfileInitialization"}, SelectReturnType = typeof(Amazon.NimbleStudio.Model.GetLaunchProfileInitializationResponse))]
    [AWSCmdletOutput("Amazon.NimbleStudio.Model.LaunchProfileInitialization or Amazon.NimbleStudio.Model.GetLaunchProfileInitializationResponse",
        "This cmdlet returns an Amazon.NimbleStudio.Model.LaunchProfileInitialization object.",
        "The service call response (type Amazon.NimbleStudio.Model.GetLaunchProfileInitializationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetNSLaunchProfileInitializationCmdlet : AmazonNimbleStudioClientCmdlet, IExecutor
    {
        
        #region Parameter LaunchProfileId
        /// <summary>
        /// <para>
        /// <para>The Launch Profile ID.</para>
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
        public System.String LaunchProfileId { get; set; }
        #endregion
        
        #region Parameter LaunchProfileProtocolVersion
        /// <summary>
        /// <para>
        /// <para>The launch profile protocol versions supported by the client.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LaunchProfileProtocolVersions")]
        public System.String[] LaunchProfileProtocolVersion { get; set; }
        #endregion
        
        #region Parameter LaunchPurpose
        /// <summary>
        /// <para>
        /// <para>The launch purpose.</para>
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
        public System.String LaunchPurpose { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The platform where this Launch Profile will be used, either WINDOWS or LINUX.</para>
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
        public System.String Platform { get; set; }
        #endregion
        
        #region Parameter StudioId
        /// <summary>
        /// <para>
        /// <para>The studio ID. </para>
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
        public System.String StudioId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LaunchProfileInitialization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NimbleStudio.Model.GetLaunchProfileInitializationResponse).
        /// Specifying the name of a property of type Amazon.NimbleStudio.Model.GetLaunchProfileInitializationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LaunchProfileInitialization";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LaunchProfileId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LaunchProfileId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LaunchProfileId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NimbleStudio.Model.GetLaunchProfileInitializationResponse, GetNSLaunchProfileInitializationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LaunchProfileId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LaunchProfileId = this.LaunchProfileId;
            #if MODULAR
            if (this.LaunchProfileId == null && ParameterWasBound(nameof(this.LaunchProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LaunchProfileProtocolVersion != null)
            {
                context.LaunchProfileProtocolVersion = new List<System.String>(this.LaunchProfileProtocolVersion);
            }
            #if MODULAR
            if (this.LaunchProfileProtocolVersion == null && ParameterWasBound(nameof(this.LaunchProfileProtocolVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchProfileProtocolVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LaunchPurpose = this.LaunchPurpose;
            #if MODULAR
            if (this.LaunchPurpose == null && ParameterWasBound(nameof(this.LaunchPurpose)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchPurpose which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Platform = this.Platform;
            #if MODULAR
            if (this.Platform == null && ParameterWasBound(nameof(this.Platform)))
            {
                WriteWarning("You are passing $null as a value for parameter Platform which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StudioId = this.StudioId;
            #if MODULAR
            if (this.StudioId == null && ParameterWasBound(nameof(this.StudioId)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NimbleStudio.Model.GetLaunchProfileInitializationRequest();
            
            if (cmdletContext.LaunchProfileId != null)
            {
                request.LaunchProfileId = cmdletContext.LaunchProfileId;
            }
            if (cmdletContext.LaunchProfileProtocolVersion != null)
            {
                request.LaunchProfileProtocolVersions = cmdletContext.LaunchProfileProtocolVersion;
            }
            if (cmdletContext.LaunchPurpose != null)
            {
                request.LaunchPurpose = cmdletContext.LaunchPurpose;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
            }
            if (cmdletContext.StudioId != null)
            {
                request.StudioId = cmdletContext.StudioId;
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
        
        private Amazon.NimbleStudio.Model.GetLaunchProfileInitializationResponse CallAWSServiceOperation(IAmazonNimbleStudio client, Amazon.NimbleStudio.Model.GetLaunchProfileInitializationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nimble Studio", "GetLaunchProfileInitialization");
            try
            {
                #if DESKTOP
                return client.GetLaunchProfileInitialization(request);
                #elif CORECLR
                return client.GetLaunchProfileInitializationAsync(request).GetAwaiter().GetResult();
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
            public System.String LaunchProfileId { get; set; }
            public List<System.String> LaunchProfileProtocolVersion { get; set; }
            public System.String LaunchPurpose { get; set; }
            public System.String Platform { get; set; }
            public System.String StudioId { get; set; }
            public System.Func<Amazon.NimbleStudio.Model.GetLaunchProfileInitializationResponse, GetNSLaunchProfileInitializationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LaunchProfileInitialization;
        }
        
    }
}
