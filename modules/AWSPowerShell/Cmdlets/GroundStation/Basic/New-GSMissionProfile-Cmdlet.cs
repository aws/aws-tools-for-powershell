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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// Creates a mission profile.
    /// 
    ///  
    /// <para><code>dataflowEdges</code> is a list of lists of strings. Each lower level list of
    /// strings has two elements: a <i>from</i> ARN and a <i>to</i> ARN.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GSMissionProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Ground Station CreateMissionProfile API operation.", Operation = new[] {"CreateMissionProfile"}, SelectReturnType = typeof(Amazon.GroundStation.Model.CreateMissionProfileResponse))]
    [AWSCmdletOutput("System.String or Amazon.GroundStation.Model.CreateMissionProfileResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GroundStation.Model.CreateMissionProfileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGSMissionProfileCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContactPostPassDurationSecond
        /// <summary>
        /// <para>
        /// <para>Amount of time after a contact ends that you’d like to receive a CloudWatch event
        /// indicating the pass has finished.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContactPostPassDurationSeconds")]
        public System.Int32? ContactPostPassDurationSecond { get; set; }
        #endregion
        
        #region Parameter ContactPrePassDurationSecond
        /// <summary>
        /// <para>
        /// <para>Amount of time prior to contact start you’d like to receive a CloudWatch event indicating
        /// an upcoming pass.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContactPrePassDurationSeconds")]
        public System.Int32? ContactPrePassDurationSecond { get; set; }
        #endregion
        
        #region Parameter DataflowEdge
        /// <summary>
        /// <para>
        /// <para>A list of lists of ARNs. Each list of ARNs is an edge, with a <i>from</i><code>Config</code>
        /// and a <i>to</i><code>Config</code>.</para>
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
        [Alias("DataflowEdges")]
        public System.String[][] DataflowEdge { get; set; }
        #endregion
        
        #region Parameter StreamsKmsKey_KmsAliasArn
        /// <summary>
        /// <para>
        /// <para>KMS Alias Arn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamsKmsKey_KmsAliasArn { get; set; }
        #endregion
        
        #region Parameter StreamsKmsKey_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>KMS Key Arn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamsKmsKey_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter MinimumViableContactDurationSecond
        /// <summary>
        /// <para>
        /// <para>Smallest amount of time in seconds that you’d like to see for an available contact.
        /// AWS Ground Station will not present you with contacts shorter than this duration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MinimumViableContactDurationSeconds")]
        public System.Int32? MinimumViableContactDurationSecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of a mission profile.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StreamsKmsRole
        /// <summary>
        /// <para>
        /// <para>Role to use for encrypting streams with KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamsKmsRole { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags assigned to a mission profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TrackingConfigArn
        /// <summary>
        /// <para>
        /// <para>ARN of a tracking <code>Config</code>.</para>
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
        public System.String TrackingConfigArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MissionProfileId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.CreateMissionProfileResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.CreateMissionProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MissionProfileId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GSMissionProfile (CreateMissionProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.CreateMissionProfileResponse, NewGSMissionProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContactPostPassDurationSecond = this.ContactPostPassDurationSecond;
            context.ContactPrePassDurationSecond = this.ContactPrePassDurationSecond;
            if (this.DataflowEdge != null)
            {
                context.DataflowEdge = new List<List<System.String>>();
                foreach (var innerList in this.DataflowEdge)
                {
                    context.DataflowEdge.Add(new List<System.String>(innerList));
                }
            }
            #if MODULAR
            if (this.DataflowEdge == null && ParameterWasBound(nameof(this.DataflowEdge)))
            {
                WriteWarning("You are passing $null as a value for parameter DataflowEdge which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinimumViableContactDurationSecond = this.MinimumViableContactDurationSecond;
            #if MODULAR
            if (this.MinimumViableContactDurationSecond == null && ParameterWasBound(nameof(this.MinimumViableContactDurationSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter MinimumViableContactDurationSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamsKmsKey_KmsAliasArn = this.StreamsKmsKey_KmsAliasArn;
            context.StreamsKmsKey_KmsKeyArn = this.StreamsKmsKey_KmsKeyArn;
            context.StreamsKmsRole = this.StreamsKmsRole;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.TrackingConfigArn = this.TrackingConfigArn;
            #if MODULAR
            if (this.TrackingConfigArn == null && ParameterWasBound(nameof(this.TrackingConfigArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackingConfigArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GroundStation.Model.CreateMissionProfileRequest();
            
            if (cmdletContext.ContactPostPassDurationSecond != null)
            {
                request.ContactPostPassDurationSeconds = cmdletContext.ContactPostPassDurationSecond.Value;
            }
            if (cmdletContext.ContactPrePassDurationSecond != null)
            {
                request.ContactPrePassDurationSeconds = cmdletContext.ContactPrePassDurationSecond.Value;
            }
            if (cmdletContext.DataflowEdge != null)
            {
                request.DataflowEdges = cmdletContext.DataflowEdge;
            }
            if (cmdletContext.MinimumViableContactDurationSecond != null)
            {
                request.MinimumViableContactDurationSeconds = cmdletContext.MinimumViableContactDurationSecond.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate StreamsKmsKey
            var requestStreamsKmsKeyIsNull = true;
            request.StreamsKmsKey = new Amazon.GroundStation.Model.KmsKey();
            System.String requestStreamsKmsKey_streamsKmsKey_KmsAliasArn = null;
            if (cmdletContext.StreamsKmsKey_KmsAliasArn != null)
            {
                requestStreamsKmsKey_streamsKmsKey_KmsAliasArn = cmdletContext.StreamsKmsKey_KmsAliasArn;
            }
            if (requestStreamsKmsKey_streamsKmsKey_KmsAliasArn != null)
            {
                request.StreamsKmsKey.KmsAliasArn = requestStreamsKmsKey_streamsKmsKey_KmsAliasArn;
                requestStreamsKmsKeyIsNull = false;
            }
            System.String requestStreamsKmsKey_streamsKmsKey_KmsKeyArn = null;
            if (cmdletContext.StreamsKmsKey_KmsKeyArn != null)
            {
                requestStreamsKmsKey_streamsKmsKey_KmsKeyArn = cmdletContext.StreamsKmsKey_KmsKeyArn;
            }
            if (requestStreamsKmsKey_streamsKmsKey_KmsKeyArn != null)
            {
                request.StreamsKmsKey.KmsKeyArn = requestStreamsKmsKey_streamsKmsKey_KmsKeyArn;
                requestStreamsKmsKeyIsNull = false;
            }
             // determine if request.StreamsKmsKey should be set to null
            if (requestStreamsKmsKeyIsNull)
            {
                request.StreamsKmsKey = null;
            }
            if (cmdletContext.StreamsKmsRole != null)
            {
                request.StreamsKmsRole = cmdletContext.StreamsKmsRole;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrackingConfigArn != null)
            {
                request.TrackingConfigArn = cmdletContext.TrackingConfigArn;
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
        
        private Amazon.GroundStation.Model.CreateMissionProfileResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.CreateMissionProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "CreateMissionProfile");
            try
            {
                #if DESKTOP
                return client.CreateMissionProfile(request);
                #elif CORECLR
                return client.CreateMissionProfileAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ContactPostPassDurationSecond { get; set; }
            public System.Int32? ContactPrePassDurationSecond { get; set; }
            public List<List<System.String>> DataflowEdge { get; set; }
            public System.Int32? MinimumViableContactDurationSecond { get; set; }
            public System.String Name { get; set; }
            public System.String StreamsKmsKey_KmsAliasArn { get; set; }
            public System.String StreamsKmsKey_KmsKeyArn { get; set; }
            public System.String StreamsKmsRole { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TrackingConfigArn { get; set; }
            public System.Func<Amazon.GroundStation.Model.CreateMissionProfileResponse, NewGSMissionProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MissionProfileId;
        }
        
    }
}
