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
using Amazon.Finspace;
using Amazon.Finspace.Model;

namespace Amazon.PowerShell.Cmdlets.FINSP
{
    /// <summary>
    /// Updates the throughput or capacity of a volume. During the update process, the filesystem
    /// might be unavailable for a few minutes. You can retry any operations after the update
    /// is complete.
    /// </summary>
    [Cmdlet("Update", "FINSPKxVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Finspace.Model.UpdateKxVolumeResponse")]
    [AWSCmdlet("Calls the FinSpace User Environment Management Service UpdateKxVolume API operation.", Operation = new[] {"UpdateKxVolume"}, SelectReturnType = typeof(Amazon.Finspace.Model.UpdateKxVolumeResponse))]
    [AWSCmdletOutput("Amazon.Finspace.Model.UpdateKxVolumeResponse",
        "This cmdlet returns an Amazon.Finspace.Model.UpdateKxVolumeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateFINSPKxVolumeCmdlet : AmazonFinspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A description of the volume. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the kdb environment where you created the storage volume.
        /// </para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter Nas1Configuration_Size
        /// <summary>
        /// <para>
        /// <para> The size of the network attached storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Nas1Configuration_Size { get; set; }
        #endregion
        
        #region Parameter Nas1Configuration_Type
        /// <summary>
        /// <para>
        /// <para> The type of the network attached storage. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Finspace.KxNAS1Type")]
        public Amazon.Finspace.KxNAS1Type Nas1Configuration_Type { get; set; }
        #endregion
        
        #region Parameter VolumeName
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the volume.</para>
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
        public System.String VolumeName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Finspace.Model.UpdateKxVolumeResponse).
        /// Specifying the name of a property of type Amazon.Finspace.Model.UpdateKxVolumeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VolumeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VolumeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VolumeName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FINSPKxVolume (UpdateKxVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Finspace.Model.UpdateKxVolumeResponse, UpdateFINSPKxVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VolumeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Nas1Configuration_Size = this.Nas1Configuration_Size;
            context.Nas1Configuration_Type = this.Nas1Configuration_Type;
            context.VolumeName = this.VolumeName;
            #if MODULAR
            if (this.VolumeName == null && ParameterWasBound(nameof(this.VolumeName)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Finspace.Model.UpdateKxVolumeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            
             // populate Nas1Configuration
            var requestNas1ConfigurationIsNull = true;
            request.Nas1Configuration = new Amazon.Finspace.Model.KxNAS1Configuration();
            System.Int32? requestNas1Configuration_nas1Configuration_Size = null;
            if (cmdletContext.Nas1Configuration_Size != null)
            {
                requestNas1Configuration_nas1Configuration_Size = cmdletContext.Nas1Configuration_Size.Value;
            }
            if (requestNas1Configuration_nas1Configuration_Size != null)
            {
                request.Nas1Configuration.Size = requestNas1Configuration_nas1Configuration_Size.Value;
                requestNas1ConfigurationIsNull = false;
            }
            Amazon.Finspace.KxNAS1Type requestNas1Configuration_nas1Configuration_Type = null;
            if (cmdletContext.Nas1Configuration_Type != null)
            {
                requestNas1Configuration_nas1Configuration_Type = cmdletContext.Nas1Configuration_Type;
            }
            if (requestNas1Configuration_nas1Configuration_Type != null)
            {
                request.Nas1Configuration.Type = requestNas1Configuration_nas1Configuration_Type;
                requestNas1ConfigurationIsNull = false;
            }
             // determine if request.Nas1Configuration should be set to null
            if (requestNas1ConfigurationIsNull)
            {
                request.Nas1Configuration = null;
            }
            if (cmdletContext.VolumeName != null)
            {
                request.VolumeName = cmdletContext.VolumeName;
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
        
        private Amazon.Finspace.Model.UpdateKxVolumeResponse CallAWSServiceOperation(IAmazonFinspace client, Amazon.Finspace.Model.UpdateKxVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace User Environment Management Service", "UpdateKxVolume");
            try
            {
                #if DESKTOP
                return client.UpdateKxVolume(request);
                #elif CORECLR
                return client.UpdateKxVolumeAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.Int32? Nas1Configuration_Size { get; set; }
            public Amazon.Finspace.KxNAS1Type Nas1Configuration_Type { get; set; }
            public System.String VolumeName { get; set; }
            public System.Func<Amazon.Finspace.Model.UpdateKxVolumeResponse, UpdateFINSPKxVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
