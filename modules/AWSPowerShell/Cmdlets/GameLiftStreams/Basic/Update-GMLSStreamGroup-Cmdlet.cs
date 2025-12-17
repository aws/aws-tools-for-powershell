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
    /// Updates the configuration settings for an Amazon GameLift Streams stream group resource.
    /// To update a stream group, it must be in <c>ACTIVE</c> status. You can change the description,
    /// the set of locations, and the requested capacity of a stream group per location. If
    /// you want to change the stream class, create a new stream group. 
    /// 
    ///  
    /// <para>
    ///  Stream capacity represents the number of concurrent streams that can be active at
    /// a time. You set stream capacity per location, per stream group. The following capacity
    /// settings are available: 
    /// </para><ul><li><para><b>Always-on capacity</b>: This setting, if non-zero, indicates minimum streaming
    /// capacity which is allocated to you and is never released back to the service. You
    /// pay for this base level of capacity at all times, whether used or idle. 
    /// </para></li><li><para><b>Maximum capacity</b>: This indicates the maximum capacity that the service can
    /// allocate for you. Newly created streams may take a few minutes to start. Capacity
    /// is released back to the service when idle. You pay for capacity that is allocated
    /// to you until it is released. 
    /// </para></li><li><para><b>Target-idle capacity</b>: This indicates idle capacity which the service pre-allocates
    /// and holds for you in anticipation of future activity. This helps to insulate your
    /// users from capacity-allocation delays. You pay for capacity which is held in this
    /// intentional idle state. 
    /// </para></li></ul><para>
    /// Values for capacity must be whole number multiples of the tenancy value of the stream
    /// group's stream class.
    /// </para><para>
    /// To update a stream group, specify the stream group's Amazon Resource Name (ARN) and
    /// provide the new values. If the request is successful, Amazon GameLift Streams returns
    /// the complete updated metadata for the stream group. Expired stream groups cannot be
    /// updated.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GMLSStreamGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse")]
    [AWSCmdlet("Calls the Amazon GameLiftStreams UpdateStreamGroup API operation.", Operation = new[] {"UpdateStreamGroup"}, SelectReturnType = typeof(Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse))]
    [AWSCmdletOutput("Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse",
        "This cmdlet returns an Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse object containing multiple properties."
    )]
    public partial class UpdateGMLSStreamGroupCmdlet : AmazonGameLiftStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultApplicationIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon GameLift Streams application that you want to
        /// set as the default application in a stream group. The application that you specify
        /// must be in <c>READY</c> status. The default application is pre-cached on always-on
        /// compute resources, reducing stream startup times. Other applications are automatically
        /// cached as needed.</para><para>Note that this parameter only sets the default application in a stream group. To associate
        /// a new application to an existing stream group, you must use <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_AssociateApplications.html">AssociateApplications</a>.</para><para>When you switch default applications in a stream group, it can take up to a few hours
        /// for the new default application to be pre-cached.</para><para>This value is an <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the application resource. Example
        /// ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:application/a-9ZY8X7Wv6</c>.
        /// Example ID: <c>a-9ZY8X7Wv6</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultApplicationIdentifier { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A descriptive label for the stream group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>An <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream group resource.
        /// Example ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:streamgroup/sg-1AB2C3De4</c>.
        /// Example ID: <c>sg-1AB2C3De4</c>. </para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter LocationConfiguration
        /// <summary>
        /// <para>
        /// <para> A set of one or more locations and the streaming capacity for each location. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LocationConfigurations")]
        public Amazon.GameLiftStreams.Model.LocationConfiguration[] LocationConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse).
        /// Specifying the name of a property of type Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLSStreamGroup (UpdateStreamGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse, UpdateGMLSStreamGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultApplicationIdentifier = this.DefaultApplicationIdentifier;
            context.Description = this.Description;
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
            var request = new Amazon.GameLiftStreams.Model.UpdateStreamGroupRequest();
            
            if (cmdletContext.DefaultApplicationIdentifier != null)
            {
                request.DefaultApplicationIdentifier = cmdletContext.DefaultApplicationIdentifier;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
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
        
        private Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse CallAWSServiceOperation(IAmazonGameLiftStreams client, Amazon.GameLiftStreams.Model.UpdateStreamGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLiftStreams", "UpdateStreamGroup");
            try
            {
                #if DESKTOP
                return client.UpdateStreamGroup(request);
                #elif CORECLR
                return client.UpdateStreamGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String DefaultApplicationIdentifier { get; set; }
            public System.String Description { get; set; }
            public System.String Identifier { get; set; }
            public List<Amazon.GameLiftStreams.Model.LocationConfiguration> LocationConfiguration { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse, UpdateGMLSStreamGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
