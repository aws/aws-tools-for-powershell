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
using System.Threading;
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Retrieves information about a device definition version.<br/><br/>In the AWS.Tools.Greengrass module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GGDeviceDefinitionVersion")]
    [OutputType("Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse")]
    [AWSCmdlet("Calls the AWS Greengrass GetDeviceDefinitionVersion API operation.", Operation = new[] {"GetDeviceDefinitionVersion"}, SelectReturnType = typeof(Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse))]
    [AWSCmdletOutput("Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse",
        "This cmdlet returns an Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse object containing multiple properties."
    )]
    public partial class GetGGDeviceDefinitionVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeviceDefinitionId
        /// <summary>
        /// <para>
        /// The ID of the device definition.
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
        public System.String DeviceDefinitionId { get; set; }
        #endregion
        
        #region Parameter DeviceDefinitionVersionId
        /// <summary>
        /// <para>
        /// The ID of the device definition
        /// version. This value maps to the ''Version'' property of the corresponding ''VersionInformation''
        /// object, which is returned by ''ListDeviceDefinitionVersions'' requests. If the version
        /// is the last one that was associated with a device definition, the value also maps
        /// to the ''LatestVersion'' property of the corresponding ''DefinitionInformation'' object.
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
        public System.String DeviceDefinitionVersionId { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The token for the next set of results, or ''null''
        /// if there are no additional results.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.Greengrass module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse).
        /// Specifying the name of a property of type Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse, GetGGDeviceDefinitionVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeviceDefinitionId = this.DeviceDefinitionId;
            #if MODULAR
            if (this.DeviceDefinitionId == null && ParameterWasBound(nameof(this.DeviceDefinitionId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceDefinitionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceDefinitionVersionId = this.DeviceDefinitionVersionId;
            #if MODULAR
            if (this.DeviceDefinitionVersionId == null && ParameterWasBound(nameof(this.DeviceDefinitionVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceDefinitionVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Greengrass.Model.GetDeviceDefinitionVersionRequest();
            
            if (cmdletContext.DeviceDefinitionId != null)
            {
                request.DeviceDefinitionId = cmdletContext.DeviceDefinitionId;
            }
            if (cmdletContext.DeviceDefinitionVersionId != null)
            {
                request.DeviceDefinitionVersionId = cmdletContext.DeviceDefinitionVersionId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Greengrass.Model.GetDeviceDefinitionVersionRequest();
            
            if (cmdletContext.DeviceDefinitionId != null)
            {
                request.DeviceDefinitionId = cmdletContext.DeviceDefinitionId;
            }
            if (cmdletContext.DeviceDefinitionVersionId != null)
            {
                request.DeviceDefinitionVersionId = cmdletContext.DeviceDefinitionVersionId;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.GetDeviceDefinitionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "GetDeviceDefinitionVersion");
            try
            {
                return client.GetDeviceDefinitionVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeviceDefinitionId { get; set; }
            public System.String DeviceDefinitionVersionId { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Greengrass.Model.GetDeviceDefinitionVersionResponse, GetGGDeviceDefinitionVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
