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
using Amazon.GameLiftStreams;
using Amazon.GameLiftStreams.Model;

namespace Amazon.PowerShell.Cmdlets.GMLS
{
    /// <summary>
    /// Add locations that can host stream sessions. To add a location, the stream group
    /// must be in <c>ACTIVE</c> status. You configure locations and their corresponding capacity
    /// for each stream group. Creating a stream group in a location that's nearest to your
    /// end users can help minimize latency and improve quality. 
    /// 
    ///  
    /// <para>
    ///  This operation provisions stream capacity at the specified locations. By default,
    /// all locations have 1 or 2 capacity, depending on the stream class option: 2 for 'High'
    /// and 1 for 'Ultra' and 'Win2022'. This operation also copies the content files of all
    /// associated applications to an internal S3 bucket at each location. This allows Amazon
    /// GameLift Streams to host performant stream sessions. 
    /// </para>
    /// </summary>
    [Cmdlet("Add", "GMLSStreamGroupLocation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLiftStreams.Model.AddStreamGroupLocationsResponse")]
    [AWSCmdlet("Calls the Amazon GameLiftStreams AddStreamGroupLocations API operation.", Operation = new[] {"AddStreamGroupLocations"}, SelectReturnType = typeof(Amazon.GameLiftStreams.Model.AddStreamGroupLocationsResponse))]
    [AWSCmdletOutput("Amazon.GameLiftStreams.Model.AddStreamGroupLocationsResponse",
        "This cmdlet returns an Amazon.GameLiftStreams.Model.AddStreamGroupLocationsResponse object containing multiple properties."
    )]
    public partial class AddGMLSStreamGroupLocationCmdlet : AmazonGameLiftStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para> A stream group to add the specified locations to. </para><para>This value is an <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream group resource.
        /// Example ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:streamgroup/sg-1AB2C3De4</c>.
        /// Example ID: <c>sg-1AB2C3De4</c>. </para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter LocationConfiguration
        /// <summary>
        /// <para>
        /// <para> A set of one or more locations and the streaming capacity for each location. </para>
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
        [Alias("LocationConfigurations")]
        public Amazon.GameLiftStreams.Model.LocationConfiguration[] LocationConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLiftStreams.Model.AddStreamGroupLocationsResponse).
        /// Specifying the name of a property of type Amazon.GameLiftStreams.Model.AddStreamGroupLocationsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-GMLSStreamGroupLocation (AddStreamGroupLocations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.AddStreamGroupLocationsResponse, AddGMLSStreamGroupLocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LocationConfiguration != null)
            {
                context.LocationConfiguration = new List<Amazon.GameLiftStreams.Model.LocationConfiguration>(this.LocationConfiguration);
            }
            #if MODULAR
            if (this.LocationConfiguration == null && ParameterWasBound(nameof(this.LocationConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLiftStreams.Model.AddStreamGroupLocationsRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.LocationConfiguration != null)
            {
                request.LocationConfigurations = cmdletContext.LocationConfiguration;
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
        
        private Amazon.GameLiftStreams.Model.AddStreamGroupLocationsResponse CallAWSServiceOperation(IAmazonGameLiftStreams client, Amazon.GameLiftStreams.Model.AddStreamGroupLocationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLiftStreams", "AddStreamGroupLocations");
            try
            {
                #if DESKTOP
                return client.AddStreamGroupLocations(request);
                #elif CORECLR
                return client.AddStreamGroupLocationsAsync(request).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public List<Amazon.GameLiftStreams.Model.LocationConfiguration> LocationConfiguration { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.AddStreamGroupLocationsResponse, AddGMLSStreamGroupLocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
