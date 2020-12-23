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
using Amazon.HealthLake;
using Amazon.HealthLake.Model;

namespace Amazon.PowerShell.Cmdlets.AHL
{
    /// <summary>
    /// Creates a Data Store that can ingest and export FHIR formatted data.
    /// </summary>
    [Cmdlet("New", "AHLFHIRDatastore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.HealthLake.Model.CreateFHIRDatastoreResponse")]
    [AWSCmdlet("Calls the Amazon HealthLake CreateFHIRDatastore API operation.", Operation = new[] {"CreateFHIRDatastore"}, SelectReturnType = typeof(Amazon.HealthLake.Model.CreateFHIRDatastoreResponse))]
    [AWSCmdletOutput("Amazon.HealthLake.Model.CreateFHIRDatastoreResponse",
        "This cmdlet returns an Amazon.HealthLake.Model.CreateFHIRDatastoreResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAHLFHIRDatastoreCmdlet : AmazonHealthLakeClientCmdlet, IExecutor
    {
        
        #region Parameter DatastoreName
        /// <summary>
        /// <para>
        /// <para>The user generated name for the Data Store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatastoreName { get; set; }
        #endregion
        
        #region Parameter DatastoreTypeVersion
        /// <summary>
        /// <para>
        /// <para>The FHIR version of the Data Store. The only supported version is R4.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.HealthLake.FHIRVersion")]
        public Amazon.HealthLake.FHIRVersion DatastoreTypeVersion { get; set; }
        #endregion
        
        #region Parameter PreloadDataConfig_PreloadDataType
        /// <summary>
        /// <para>
        /// <para>The type of preloaded data. Only Synthea preloaded data is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.HealthLake.PreloadDataType")]
        public Amazon.HealthLake.PreloadDataType PreloadDataConfig_PreloadDataType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Optional user provided token used for ensuring idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.HealthLake.Model.CreateFHIRDatastoreResponse).
        /// Specifying the name of a property of type Amazon.HealthLake.Model.CreateFHIRDatastoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatastoreTypeVersion parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatastoreTypeVersion' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatastoreTypeVersion' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatastoreName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AHLFHIRDatastore (CreateFHIRDatastore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.HealthLake.Model.CreateFHIRDatastoreResponse, NewAHLFHIRDatastoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatastoreTypeVersion;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DatastoreName = this.DatastoreName;
            context.DatastoreTypeVersion = this.DatastoreTypeVersion;
            #if MODULAR
            if (this.DatastoreTypeVersion == null && ParameterWasBound(nameof(this.DatastoreTypeVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter DatastoreTypeVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PreloadDataConfig_PreloadDataType = this.PreloadDataConfig_PreloadDataType;
            
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
            var request = new Amazon.HealthLake.Model.CreateFHIRDatastoreRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatastoreName != null)
            {
                request.DatastoreName = cmdletContext.DatastoreName;
            }
            if (cmdletContext.DatastoreTypeVersion != null)
            {
                request.DatastoreTypeVersion = cmdletContext.DatastoreTypeVersion;
            }
            
             // populate PreloadDataConfig
            var requestPreloadDataConfigIsNull = true;
            request.PreloadDataConfig = new Amazon.HealthLake.Model.PreloadDataConfig();
            Amazon.HealthLake.PreloadDataType requestPreloadDataConfig_preloadDataConfig_PreloadDataType = null;
            if (cmdletContext.PreloadDataConfig_PreloadDataType != null)
            {
                requestPreloadDataConfig_preloadDataConfig_PreloadDataType = cmdletContext.PreloadDataConfig_PreloadDataType;
            }
            if (requestPreloadDataConfig_preloadDataConfig_PreloadDataType != null)
            {
                request.PreloadDataConfig.PreloadDataType = requestPreloadDataConfig_preloadDataConfig_PreloadDataType;
                requestPreloadDataConfigIsNull = false;
            }
             // determine if request.PreloadDataConfig should be set to null
            if (requestPreloadDataConfigIsNull)
            {
                request.PreloadDataConfig = null;
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
        
        private Amazon.HealthLake.Model.CreateFHIRDatastoreResponse CallAWSServiceOperation(IAmazonHealthLake client, Amazon.HealthLake.Model.CreateFHIRDatastoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon HealthLake", "CreateFHIRDatastore");
            try
            {
                #if DESKTOP
                return client.CreateFHIRDatastore(request);
                #elif CORECLR
                return client.CreateFHIRDatastoreAsync(request).GetAwaiter().GetResult();
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
            public System.String DatastoreName { get; set; }
            public Amazon.HealthLake.FHIRVersion DatastoreTypeVersion { get; set; }
            public Amazon.HealthLake.PreloadDataType PreloadDataConfig_PreloadDataType { get; set; }
            public System.Func<Amazon.HealthLake.Model.CreateFHIRDatastoreResponse, NewAHLFHIRDatastoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
