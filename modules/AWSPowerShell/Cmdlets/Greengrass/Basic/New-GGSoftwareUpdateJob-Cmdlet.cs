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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Creates a software update for a core or group of cores (specified as an IoT thing
    /// group.) Use this to update the OTA Agent as well as the Greengrass core software.
    /// It makes use of the IoT Jobs feature which provides additional commands to manage
    /// a Greengrass core software update job.
    /// </summary>
    [Cmdlet("New", "GGSoftwareUpdateJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse")]
    [AWSCmdlet("Calls the AWS Greengrass CreateSoftwareUpdateJob API operation.", Operation = new[] {"CreateSoftwareUpdateJob"}, SelectReturnType = typeof(Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse))]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse",
        "This cmdlet returns an Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGGSoftwareUpdateJobCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// A client token used to correlate requests
        /// and responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter S3UrlSignerRole
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String S3UrlSignerRole { get; set; }
        #endregion
        
        #region Parameter SoftwareToUpdate
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Greengrass.SoftwareToUpdate")]
        public Amazon.Greengrass.SoftwareToUpdate SoftwareToUpdate { get; set; }
        #endregion
        
        #region Parameter UpdateAgentLogLevel
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Greengrass.UpdateAgentLogLevel")]
        public Amazon.Greengrass.UpdateAgentLogLevel UpdateAgentLogLevel { get; set; }
        #endregion
        
        #region Parameter UpdateTarget
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        [Alias("UpdateTargets")]
        public System.String[] UpdateTarget { get; set; }
        #endregion
        
        #region Parameter UpdateTargetsArchitecture
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Greengrass.UpdateTargetsArchitecture")]
        public Amazon.Greengrass.UpdateTargetsArchitecture UpdateTargetsArchitecture { get; set; }
        #endregion
        
        #region Parameter UpdateTargetsOperatingSystem
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Greengrass.UpdateTargetsOperatingSystem")]
        public Amazon.Greengrass.UpdateTargetsOperatingSystem UpdateTargetsOperatingSystem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse).
        /// Specifying the name of a property of type Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGSoftwareUpdateJob (CreateSoftwareUpdateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse, NewGGSoftwareUpdateJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmznClientToken = this.AmznClientToken;
            context.S3UrlSignerRole = this.S3UrlSignerRole;
            #if MODULAR
            if (this.S3UrlSignerRole == null && ParameterWasBound(nameof(this.S3UrlSignerRole)))
            {
                WriteWarning("You are passing $null as a value for parameter S3UrlSignerRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SoftwareToUpdate = this.SoftwareToUpdate;
            #if MODULAR
            if (this.SoftwareToUpdate == null && ParameterWasBound(nameof(this.SoftwareToUpdate)))
            {
                WriteWarning("You are passing $null as a value for parameter SoftwareToUpdate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateAgentLogLevel = this.UpdateAgentLogLevel;
            if (this.UpdateTarget != null)
            {
                context.UpdateTarget = new List<System.String>(this.UpdateTarget);
            }
            #if MODULAR
            if (this.UpdateTarget == null && ParameterWasBound(nameof(this.UpdateTarget)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateTarget which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateTargetsArchitecture = this.UpdateTargetsArchitecture;
            #if MODULAR
            if (this.UpdateTargetsArchitecture == null && ParameterWasBound(nameof(this.UpdateTargetsArchitecture)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateTargetsArchitecture which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateTargetsOperatingSystem = this.UpdateTargetsOperatingSystem;
            #if MODULAR
            if (this.UpdateTargetsOperatingSystem == null && ParameterWasBound(nameof(this.UpdateTargetsOperatingSystem)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateTargetsOperatingSystem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Greengrass.Model.CreateSoftwareUpdateJobRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            if (cmdletContext.S3UrlSignerRole != null)
            {
                request.S3UrlSignerRole = cmdletContext.S3UrlSignerRole;
            }
            if (cmdletContext.SoftwareToUpdate != null)
            {
                request.SoftwareToUpdate = cmdletContext.SoftwareToUpdate;
            }
            if (cmdletContext.UpdateAgentLogLevel != null)
            {
                request.UpdateAgentLogLevel = cmdletContext.UpdateAgentLogLevel;
            }
            if (cmdletContext.UpdateTarget != null)
            {
                request.UpdateTargets = cmdletContext.UpdateTarget;
            }
            if (cmdletContext.UpdateTargetsArchitecture != null)
            {
                request.UpdateTargetsArchitecture = cmdletContext.UpdateTargetsArchitecture;
            }
            if (cmdletContext.UpdateTargetsOperatingSystem != null)
            {
                request.UpdateTargetsOperatingSystem = cmdletContext.UpdateTargetsOperatingSystem;
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
        
        private Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateSoftwareUpdateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateSoftwareUpdateJob");
            try
            {
                #if DESKTOP
                return client.CreateSoftwareUpdateJob(request);
                #elif CORECLR
                return client.CreateSoftwareUpdateJobAsync(request).GetAwaiter().GetResult();
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
            public System.String AmznClientToken { get; set; }
            public System.String S3UrlSignerRole { get; set; }
            public Amazon.Greengrass.SoftwareToUpdate SoftwareToUpdate { get; set; }
            public Amazon.Greengrass.UpdateAgentLogLevel UpdateAgentLogLevel { get; set; }
            public List<System.String> UpdateTarget { get; set; }
            public Amazon.Greengrass.UpdateTargetsArchitecture UpdateTargetsArchitecture { get; set; }
            public Amazon.Greengrass.UpdateTargetsOperatingSystem UpdateTargetsOperatingSystem { get; set; }
            public System.Func<Amazon.Greengrass.Model.CreateSoftwareUpdateJobResponse, NewGGSoftwareUpdateJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
