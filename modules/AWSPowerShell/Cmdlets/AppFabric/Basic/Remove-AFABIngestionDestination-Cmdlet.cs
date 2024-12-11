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
using Amazon.AppFabric;
using Amazon.AppFabric.Model;

namespace Amazon.PowerShell.Cmdlets.AFAB
{
    /// <summary>
    /// Deletes an ingestion destination.
    /// 
    ///  
    /// <para>
    /// This deletes the association between an ingestion and it's destination. It doesn't
    /// delete previously ingested data or the storage destination, such as the Amazon S3
    /// bucket where the data is delivered. If the ingestion destination is deleted while
    /// the associated ingestion is enabled, the ingestion will fail and is eventually disabled.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "AFABIngestionDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Web Services AppFabric DeleteIngestionDestination API operation.", Operation = new[] {"DeleteIngestionDestination"}, SelectReturnType = typeof(Amazon.AppFabric.Model.DeleteIngestionDestinationResponse))]
    [AWSCmdletOutput("None or Amazon.AppFabric.Model.DeleteIngestionDestinationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AppFabric.Model.DeleteIngestionDestinationResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveAFABIngestionDestinationCmdlet : AmazonAppFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppBundleIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app bundle
        /// to use for the request.</para>
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
        public System.String AppBundleIdentifier { get; set; }
        #endregion
        
        #region Parameter IngestionDestinationIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the ingestion
        /// destination to use for the request.</para>
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
        public System.String IngestionDestinationIdentifier { get; set; }
        #endregion
        
        #region Parameter IngestionIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the ingestion
        /// to use for the request.</para>
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
        public System.String IngestionIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppFabric.Model.DeleteIngestionDestinationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IngestionDestinationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-AFABIngestionDestination (DeleteIngestionDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppFabric.Model.DeleteIngestionDestinationResponse, RemoveAFABIngestionDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppBundleIdentifier = this.AppBundleIdentifier;
            #if MODULAR
            if (this.AppBundleIdentifier == null && ParameterWasBound(nameof(this.AppBundleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBundleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IngestionDestinationIdentifier = this.IngestionDestinationIdentifier;
            #if MODULAR
            if (this.IngestionDestinationIdentifier == null && ParameterWasBound(nameof(this.IngestionDestinationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IngestionDestinationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IngestionIdentifier = this.IngestionIdentifier;
            #if MODULAR
            if (this.IngestionIdentifier == null && ParameterWasBound(nameof(this.IngestionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IngestionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppFabric.Model.DeleteIngestionDestinationRequest();
            
            if (cmdletContext.AppBundleIdentifier != null)
            {
                request.AppBundleIdentifier = cmdletContext.AppBundleIdentifier;
            }
            if (cmdletContext.IngestionDestinationIdentifier != null)
            {
                request.IngestionDestinationIdentifier = cmdletContext.IngestionDestinationIdentifier;
            }
            if (cmdletContext.IngestionIdentifier != null)
            {
                request.IngestionIdentifier = cmdletContext.IngestionIdentifier;
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
        
        private Amazon.AppFabric.Model.DeleteIngestionDestinationResponse CallAWSServiceOperation(IAmazonAppFabric client, Amazon.AppFabric.Model.DeleteIngestionDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Web Services AppFabric", "DeleteIngestionDestination");
            try
            {
                #if DESKTOP
                return client.DeleteIngestionDestination(request);
                #elif CORECLR
                return client.DeleteIngestionDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.String AppBundleIdentifier { get; set; }
            public System.String IngestionDestinationIdentifier { get; set; }
            public System.String IngestionIdentifier { get; set; }
            public System.Func<Amazon.AppFabric.Model.DeleteIngestionDestinationResponse, RemoveAFABIngestionDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
