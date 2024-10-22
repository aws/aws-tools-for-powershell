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
using Amazon.FinSpaceData;
using Amazon.FinSpaceData.Model;

namespace Amazon.PowerShell.Cmdlets.FNSP
{
    /// <summary>
    /// A temporary Amazon S3 location, where you can copy your files from a source location
    /// to stage or use as a scratch space in FinSpace notebook.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "FNSPWorkingLocation")]
    [OutputType("Amazon.FinSpaceData.Model.GetWorkingLocationResponse")]
    [AWSCmdlet("Calls the FinSpace Public API GetWorkingLocation API operation.", Operation = new[] {"GetWorkingLocation"}, SelectReturnType = typeof(Amazon.FinSpaceData.Model.GetWorkingLocationResponse))]
    [AWSCmdletOutput("Amazon.FinSpaceData.Model.GetWorkingLocationResponse",
        "This cmdlet returns an Amazon.FinSpaceData.Model.GetWorkingLocationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("This method will be discontinued.")]
    public partial class GetFNSPWorkingLocationCmdlet : AmazonFinSpaceDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LocationType
        /// <summary>
        /// <para>
        /// <para>Specify the type of the working location.</para><ul><li><para><c>SAGEMAKER</c> – Use the Amazon S3 location as a temporary location to store data
        /// content when working with FinSpace Notebooks that run on SageMaker studio.</para></li><li><para><c>INGESTION</c> – Use the Amazon S3 location as a staging location to copy your
        /// data content and then use the location with the Changeset creation operation.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.FinSpaceData.LocationType")]
        public Amazon.FinSpaceData.LocationType LocationType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FinSpaceData.Model.GetWorkingLocationResponse).
        /// Specifying the name of a property of type Amazon.FinSpaceData.Model.GetWorkingLocationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FinSpaceData.Model.GetWorkingLocationResponse, GetFNSPWorkingLocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LocationType = this.LocationType;
            
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
            var request = new Amazon.FinSpaceData.Model.GetWorkingLocationRequest();
            
            if (cmdletContext.LocationType != null)
            {
                request.LocationType = cmdletContext.LocationType;
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
        
        private Amazon.FinSpaceData.Model.GetWorkingLocationResponse CallAWSServiceOperation(IAmazonFinSpaceData client, Amazon.FinSpaceData.Model.GetWorkingLocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace Public API", "GetWorkingLocation");
            try
            {
                #if DESKTOP
                return client.GetWorkingLocation(request);
                #elif CORECLR
                return client.GetWorkingLocationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.FinSpaceData.LocationType LocationType { get; set; }
            public System.Func<Amazon.FinSpaceData.Model.GetWorkingLocationResponse, GetFNSPWorkingLocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
