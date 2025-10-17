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
using Amazon.GameLiftStreams;
using Amazon.GameLiftStreams.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GMLS
{
    /// <summary>
    /// Updates the configuration settings for an Amazon GameLift Streams stream group resource.
    /// You can change the description, the set of locations, and the requested capacity of
    /// a stream group per location. If you want to change the stream class, create a new
    /// stream group. 
    /// 
    ///  
    /// <para>
    ///  Stream capacity represents the number of concurrent streams that can be active at
    /// a time. You set stream capacity per location, per stream group. There are two types
    /// of capacity, always-on and on-demand: 
    /// </para><ul><li><para><b>Always-on</b>: The streaming capacity that is allocated and ready to handle stream
    /// requests without delay. You pay for this capacity whether it's in use or not. Best
    /// for quickest time from streaming request to streaming session. Default is 1 (2 for
    /// high stream classes) when creating a stream group or adding a location. 
    /// </para></li><li><para><b>On-demand</b>: The streaming capacity that Amazon GameLift Streams can allocate
    /// in response to stream requests, and then de-allocate when the session has terminated.
    /// This offers a cost control measure at the expense of a greater startup time (typically
    /// under 5 minutes). Default is 0 when creating a stream group or adding a location.
    /// 
    /// </para></li></ul><para>
    /// Values for capacity must be whole number multiples of the tenancy value of the stream
    /// group's stream class.
    /// </para><para>
    /// To update a stream group, specify the stream group's Amazon Resource Name (ARN) and
    /// provide the new values. If the request is successful, Amazon GameLift Streams returns
    /// the complete updated metadata for the stream group.
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
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para> A set of one or more locations and the streaming capacity for each location. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLSStreamGroup (UpdateStreamGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.UpdateStreamGroupResponse, UpdateGMLSStreamGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
                return client.UpdateStreamGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
