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
using Amazon.Panorama;
using Amazon.Panorama.Model;

namespace Amazon.PowerShell.Cmdlets.PAN
{
    /// <summary>
    /// Creates an application instance and deploys it to a device.
    /// </summary>
    [Cmdlet("New", "PANApplicationInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Panorama CreateApplicationInstance API operation.", Operation = new[] {"CreateApplicationInstance"}, SelectReturnType = typeof(Amazon.Panorama.Model.CreateApplicationInstanceResponse))]
    [AWSCmdletOutput("System.String or Amazon.Panorama.Model.CreateApplicationInstanceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Panorama.Model.CreateApplicationInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPANApplicationInstanceCmdlet : AmazonPanoramaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationInstanceIdToReplace
        /// <summary>
        /// <para>
        /// <para>The ID of an application instance to replace with the new instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationInstanceIdToReplace { get; set; }
        #endregion
        
        #region Parameter DefaultRuntimeContextDevice
        /// <summary>
        /// <para>
        /// <para>A device's ID.</para>
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
        public System.String DefaultRuntimeContextDevice { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the application instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the application instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ManifestOverridesPayload_PayloadData
        /// <summary>
        /// <para>
        /// <para>The overrides document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManifestOverridesPayload_PayloadData { get; set; }
        #endregion
        
        #region Parameter ManifestPayload_PayloadData
        /// <summary>
        /// <para>
        /// <para>The application manifest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ManifestPayload_PayloadData { get; set; }
        #endregion
        
        #region Parameter RuntimeRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of a runtime role for the application instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuntimeRoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the application instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationInstanceId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Panorama.Model.CreateApplicationInstanceResponse).
        /// Specifying the name of a property of type Amazon.Panorama.Model.CreateApplicationInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationInstanceId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DefaultRuntimeContextDevice parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DefaultRuntimeContextDevice' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DefaultRuntimeContextDevice' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DefaultRuntimeContextDevice), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PANApplicationInstance (CreateApplicationInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Panorama.Model.CreateApplicationInstanceResponse, NewPANApplicationInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DefaultRuntimeContextDevice;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationInstanceIdToReplace = this.ApplicationInstanceIdToReplace;
            context.DefaultRuntimeContextDevice = this.DefaultRuntimeContextDevice;
            #if MODULAR
            if (this.DefaultRuntimeContextDevice == null && ParameterWasBound(nameof(this.DefaultRuntimeContextDevice)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultRuntimeContextDevice which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.ManifestOverridesPayload_PayloadData = this.ManifestOverridesPayload_PayloadData;
            context.ManifestPayload_PayloadData = this.ManifestPayload_PayloadData;
            context.Name = this.Name;
            context.RuntimeRoleArn = this.RuntimeRoleArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Panorama.Model.CreateApplicationInstanceRequest();
            
            if (cmdletContext.ApplicationInstanceIdToReplace != null)
            {
                request.ApplicationInstanceIdToReplace = cmdletContext.ApplicationInstanceIdToReplace;
            }
            if (cmdletContext.DefaultRuntimeContextDevice != null)
            {
                request.DefaultRuntimeContextDevice = cmdletContext.DefaultRuntimeContextDevice;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate ManifestOverridesPayload
            var requestManifestOverridesPayloadIsNull = true;
            request.ManifestOverridesPayload = new Amazon.Panorama.Model.ManifestOverridesPayload();
            System.String requestManifestOverridesPayload_manifestOverridesPayload_PayloadData = null;
            if (cmdletContext.ManifestOverridesPayload_PayloadData != null)
            {
                requestManifestOverridesPayload_manifestOverridesPayload_PayloadData = cmdletContext.ManifestOverridesPayload_PayloadData;
            }
            if (requestManifestOverridesPayload_manifestOverridesPayload_PayloadData != null)
            {
                request.ManifestOverridesPayload.PayloadData = requestManifestOverridesPayload_manifestOverridesPayload_PayloadData;
                requestManifestOverridesPayloadIsNull = false;
            }
             // determine if request.ManifestOverridesPayload should be set to null
            if (requestManifestOverridesPayloadIsNull)
            {
                request.ManifestOverridesPayload = null;
            }
            
             // populate ManifestPayload
            var requestManifestPayloadIsNull = true;
            request.ManifestPayload = new Amazon.Panorama.Model.ManifestPayload();
            System.String requestManifestPayload_manifestPayload_PayloadData = null;
            if (cmdletContext.ManifestPayload_PayloadData != null)
            {
                requestManifestPayload_manifestPayload_PayloadData = cmdletContext.ManifestPayload_PayloadData;
            }
            if (requestManifestPayload_manifestPayload_PayloadData != null)
            {
                request.ManifestPayload.PayloadData = requestManifestPayload_manifestPayload_PayloadData;
                requestManifestPayloadIsNull = false;
            }
             // determine if request.ManifestPayload should be set to null
            if (requestManifestPayloadIsNull)
            {
                request.ManifestPayload = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RuntimeRoleArn != null)
            {
                request.RuntimeRoleArn = cmdletContext.RuntimeRoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Panorama.Model.CreateApplicationInstanceResponse CallAWSServiceOperation(IAmazonPanorama client, Amazon.Panorama.Model.CreateApplicationInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Panorama", "CreateApplicationInstance");
            try
            {
                #if DESKTOP
                return client.CreateApplicationInstance(request);
                #elif CORECLR
                return client.CreateApplicationInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationInstanceIdToReplace { get; set; }
            public System.String DefaultRuntimeContextDevice { get; set; }
            public System.String Description { get; set; }
            public System.String ManifestOverridesPayload_PayloadData { get; set; }
            public System.String ManifestPayload_PayloadData { get; set; }
            public System.String Name { get; set; }
            public System.String RuntimeRoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Panorama.Model.CreateApplicationInstanceResponse, NewPANApplicationInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationInstanceId;
        }
        
    }
}
