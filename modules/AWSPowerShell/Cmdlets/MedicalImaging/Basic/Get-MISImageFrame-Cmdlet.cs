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
using Amazon.MedicalImaging;
using Amazon.MedicalImaging.Model;

namespace Amazon.PowerShell.Cmdlets.MIS
{
    /// <summary>
    /// Get an image frame (pixel data) for an image set.
    /// </summary>
    [Cmdlet("Get", "MISImageFrame")]
    [OutputType("Amazon.MedicalImaging.Model.GetImageFrameResponse")]
    [AWSCmdlet("Calls the Amazon Medical Imaging Service GetImageFrame API operation.", Operation = new[] {"GetImageFrame"}, SelectReturnType = typeof(Amazon.MedicalImaging.Model.GetImageFrameResponse))]
    [AWSCmdletOutput("Amazon.MedicalImaging.Model.GetImageFrameResponse",
        "This cmdlet returns an Amazon.MedicalImaging.Model.GetImageFrameResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMISImageFrameCmdlet : AmazonMedicalImagingClientCmdlet, IExecutor
    {
        
        #region Parameter DatastoreId
        /// <summary>
        /// <para>
        /// <para>The data store identifier.</para>
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
        public System.String DatastoreId { get; set; }
        #endregion
        
        #region Parameter ImageFrameInformation_ImageFrameId
        /// <summary>
        /// <para>
        /// <para>The image frame (pixel data) identifier.</para>
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
        public System.String ImageFrameInformation_ImageFrameId { get; set; }
        #endregion
        
        #region Parameter ImageSetId
        /// <summary>
        /// <para>
        /// <para>The image set identifier.</para>
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
        public System.String ImageSetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MedicalImaging.Model.GetImageFrameResponse).
        /// Specifying the name of a property of type Amazon.MedicalImaging.Model.GetImageFrameResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatastoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatastoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatastoreId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.MedicalImaging.Model.GetImageFrameResponse, GetMISImageFrameCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatastoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DatastoreId = this.DatastoreId;
            #if MODULAR
            if (this.DatastoreId == null && ParameterWasBound(nameof(this.DatastoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatastoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageFrameInformation_ImageFrameId = this.ImageFrameInformation_ImageFrameId;
            #if MODULAR
            if (this.ImageFrameInformation_ImageFrameId == null && ParameterWasBound(nameof(this.ImageFrameInformation_ImageFrameId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageFrameInformation_ImageFrameId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageSetId = this.ImageSetId;
            #if MODULAR
            if (this.ImageSetId == null && ParameterWasBound(nameof(this.ImageSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MedicalImaging.Model.GetImageFrameRequest();
            
            if (cmdletContext.DatastoreId != null)
            {
                request.DatastoreId = cmdletContext.DatastoreId;
            }
            
             // populate ImageFrameInformation
            var requestImageFrameInformationIsNull = true;
            request.ImageFrameInformation = new Amazon.MedicalImaging.Model.ImageFrameInformation();
            System.String requestImageFrameInformation_imageFrameInformation_ImageFrameId = null;
            if (cmdletContext.ImageFrameInformation_ImageFrameId != null)
            {
                requestImageFrameInformation_imageFrameInformation_ImageFrameId = cmdletContext.ImageFrameInformation_ImageFrameId;
            }
            if (requestImageFrameInformation_imageFrameInformation_ImageFrameId != null)
            {
                request.ImageFrameInformation.ImageFrameId = requestImageFrameInformation_imageFrameInformation_ImageFrameId;
                requestImageFrameInformationIsNull = false;
            }
             // determine if request.ImageFrameInformation should be set to null
            if (requestImageFrameInformationIsNull)
            {
                request.ImageFrameInformation = null;
            }
            if (cmdletContext.ImageSetId != null)
            {
                request.ImageSetId = cmdletContext.ImageSetId;
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
        
        private Amazon.MedicalImaging.Model.GetImageFrameResponse CallAWSServiceOperation(IAmazonMedicalImaging client, Amazon.MedicalImaging.Model.GetImageFrameRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Medical Imaging Service", "GetImageFrame");
            try
            {
                #if DESKTOP
                return client.GetImageFrame(request);
                #elif CORECLR
                return client.GetImageFrameAsync(request).GetAwaiter().GetResult();
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
            public System.String DatastoreId { get; set; }
            public System.String ImageFrameInformation_ImageFrameId { get; set; }
            public System.String ImageSetId { get; set; }
            public System.Func<Amazon.MedicalImaging.Model.GetImageFrameResponse, GetMISImageFrameCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
