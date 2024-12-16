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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Get the latest thumbnail data for the input device.
    /// </summary>
    [Cmdlet("Get", "EMLInputDeviceThumbnail")]
    [OutputType("System.IO.Stream")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive DescribeInputDeviceThumbnail API operation.", Operation = new[] {"DescribeInputDeviceThumbnail"}, SelectReturnType = typeof(Amazon.MediaLive.Model.DescribeInputDeviceThumbnailResponse))]
    [AWSCmdletOutput("System.IO.Stream or Amazon.MediaLive.Model.DescribeInputDeviceThumbnailResponse",
        "This cmdlet returns a System.IO.Stream object.",
        "The service call response (type Amazon.MediaLive.Model.DescribeInputDeviceThumbnailResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEMLInputDeviceThumbnailCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// The HTTP Accept header. Indicates the requested
        /// type for the thumbnail.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MediaLive.AcceptHeader")]
        public Amazon.MediaLive.AcceptHeader Accept { get; set; }
        #endregion
        
        #region Parameter InputDeviceId
        /// <summary>
        /// <para>
        /// The unique ID of this input device. For
        /// example, hd-123456789abcdef.
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
        public System.String InputDeviceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Body'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.DescribeInputDeviceThumbnailResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.DescribeInputDeviceThumbnailResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Body";
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
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.DescribeInputDeviceThumbnailResponse, GetEMLInputDeviceThumbnailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accept = this.Accept;
            #if MODULAR
            if (this.Accept == null && ParameterWasBound(nameof(this.Accept)))
            {
                WriteWarning("You are passing $null as a value for parameter Accept which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDeviceId = this.InputDeviceId;
            #if MODULAR
            if (this.InputDeviceId == null && ParameterWasBound(nameof(this.InputDeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaLive.Model.DescribeInputDeviceThumbnailRequest();
            
            if (cmdletContext.Accept != null)
            {
                request.Accept = cmdletContext.Accept;
            }
            if (cmdletContext.InputDeviceId != null)
            {
                request.InputDeviceId = cmdletContext.InputDeviceId;
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
        
        private Amazon.MediaLive.Model.DescribeInputDeviceThumbnailResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.DescribeInputDeviceThumbnailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "DescribeInputDeviceThumbnail");
            try
            {
                #if DESKTOP
                return client.DescribeInputDeviceThumbnail(request);
                #elif CORECLR
                return client.DescribeInputDeviceThumbnailAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaLive.AcceptHeader Accept { get; set; }
            public System.String InputDeviceId { get; set; }
            public System.Func<Amazon.MediaLive.Model.DescribeInputDeviceThumbnailResponse, GetEMLInputDeviceThumbnailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Body;
        }
        
    }
}
