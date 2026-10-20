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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a DB capacity reservation. A DB capacity reservation reserves compute and
    /// memory capacity for DB instances of one DB instance class and one database engine.
    /// Amazon RDS reserves that capacity in each Availability Zone that you specify.
    /// 
    ///  
    /// <para>
    /// Amazon RDS reserves the same amount of capacity in every Availability Zone in the
    /// request. You set that amount with <c>CapacityPerAvailabilityZone</c>, and you set
    /// the Availability Zones with <c>AvailabilityZones</c>. The total reserved capacity
    /// is <c>CapacityPerAvailabilityZone</c> multiplied by the number of Availability Zones.
    /// </para><para>
    /// Specify <c>StartDate</c> and <c>CommitmentDuration</c> together to create a future-dated
    /// reservation. A future-dated reservation reserves capacity for a period that starts
    /// later. Amazon RDS holds that capacity for the length of the commitment.
    /// </para><para>
    /// A future-dated reservation has the following additional constraints:
    /// </para><ul><li><para><c>DBInstanceClass</c> must be a <c>db.c</c>, <c>db.m</c>, <c>db.r</c>, <c>db.t</c>,
    /// or <c>db.x</c> DB instance class. The letter after <c>db.</c> gives the DB instance
    /// class family. For example, <c>db.x2g.xlarge</c> qualifies, and <c>db.z1d.xlarge</c>
    /// doesn't.
    /// </para></li><li><para>
    /// If <c>DBInstanceClass</c> is a <c>db.m</c> or <c>db.r</c> DB instance class, it must
    /// be from generation 7 or later. The digit after the family letter gives the generation.
    /// For example, <c>db.m7g.xlarge</c> qualifies, and <c>db.m5.xlarge</c> doesn't. A <c>db.c</c>,
    /// <c>db.t</c>, or <c>db.x</c> DB instance class has no generation requirement.
    /// </para></li><li><para>
    /// The reserved capacity must total at least 32 vCPUs in each Availability Zone. Multiply
    /// <c>CapacityPerAvailabilityZone</c> by the number of vCPUs of the DB instance class.
    /// The product must be 32 or more.
    /// </para></li><li><para><c>CommitmentDuration</c> must be at least 14 days. For a <c>db.x</c> DB instance
    /// class, it must be at least 84 days.
    /// </para></li><li><para><c>StartDate</c> must be from 5 to 120 days in the future.
    /// </para></li></ul><para>
    /// Therefore, a DB instance class with 2 vCPUs needs a <c>CapacityPerAvailabilityZone</c>
    /// of 16 or more, a class with 4 vCPUs needs 8 or more, a class with 8 vCPUs needs 4
    /// or more, and a class with 16 vCPUs needs 2 or more. For the number of vCPUs of each
    /// DB instance class, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
    /// instance classes</a> in the <i>Amazon RDS User Guide</i>.
    /// </para><note><para>
    /// You can't modify a future-dated reservation before it starts. You can't cancel a future-dated
    /// reservation in the <c>scheduled</c> state. You can't cancel a reservation in the <c>active</c>
    /// state during its capacity commitment. Therefore, you can't cancel a future-dated reservation
    /// from the time that Amazon RDS schedules it until the commitment ends.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "RDSDBCapacityReservation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCapacityReservation")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBCapacityReservation API operation.", Operation = new[] {"CreateDBCapacityReservation"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateDBCapacityReservationResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCapacityReservation or Amazon.RDS.Model.CreateDBCapacityReservationResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBCapacityReservation object.",
        "The service call response (type Amazon.RDS.Model.CreateDBCapacityReservationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRDSDBCapacityReservationCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A list of Availability Zones for the reservation.</para><para>You can't change the Availability Zones of a reservation after you create it. Reserved
        /// capacity in an Availability Zone that no DB instance uses stays unused.</para><para>Constraints:</para><ul><li><para>Must specify one or more Availability Zones.</para></li><li><para>Each Availability Zone can appear only once.</para></li><li><para>Each Availability Zone must be in the Amazon Web Services Region of the request.</para></li><li><para>Each Availability Zone must have capacity for the requested DB instance class.</para></li><li><para>Must include two or more Availability Zones to use the reservation for a Multi-AZ
        /// DB instance.</para></li><li><para>A DB instance can use reserved capacity only in an Availability Zone that its DB subnet
        /// group covers.</para></li></ul><para>Example: <c>us-east-1a</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter CapacityPerAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The number of DB instances to reserve in each Availability Zone that you list in <c>AvailabilityZones</c>.
        /// Amazon RDS reserves this number of DB instances in every listed Availability Zone.</para><para>A Single-AZ DB instance uses one unit of reserved capacity, in one Availability Zone.
        /// A Multi-AZ DB instance is one DB instance, and it uses one unit of reserved capacity
        /// in each of two Availability Zones. Therefore, a Multi-AZ DB instance uses two units
        /// in total. A read replica uses one unit of reserved capacity, in the same way as any
        /// other DB instance.</para><para>Amazon RDS reserves capacity in each Availability Zone separately. Reserved capacity
        /// in one Availability Zone can't serve a DB instance in another Availability Zone. A
        /// request for a DB instance fails when the Availability Zone of the DB instance has
        /// no available capacity.</para><para>Therefore, set this value to the number of DB instances that you want to run at the
        /// same time in one Availability Zone. Don't set it to the number that you want in total.</para><para>This value multiplied by the number of Availability Zones counts against the DB instances
        /// quota for your Amazon Web Services account in the Amazon Web Services Region. Your
        /// existing DB instances, and the unused capacity of your other reservations, count against
        /// the same quota.</para><para>To find the value of the DB instances quota, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Limits.html">Quotas
        /// and constraints for Amazon RDS</a> in the <i>Amazon RDS User Guide</i>.</para><para>Constraints:</para><ul><li><para>Minimum 1.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? CapacityPerAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter CommitmentDuration
        /// <summary>
        /// <para>
        /// <para>The length of the capacity commitment that you request for a future-dated reservation,
        /// in seconds. Amazon RDS measures this length from <c>StartDate</c>.</para><note><para>Amazon RDS can grant a shorter capacity commitment than you request. Therefore, read
        /// <c>CommitmentEndDate</c> in <c>CommitmentInfo</c> for the commitment that Amazon RDS
        /// granted.</para></note><para>The commitment doesn't end the reservation. Specify <c>EndDate</c> to set an expiration
        /// date. You can't cancel a reservation in the <c>active</c> state during the commitment.</para><para>Constraints:</para><ul><li><para>Minimum 1209600, which is 14 days. For a <c>db.x</c> DB instance class, such as <c>db.x2g.xlarge</c>,
        /// the minimum is 7257600, which is 84 days.</para></li><li><para>Must be less than 315576000, which is 10 years.</para></li><li><para>You must also specify <c>StartDate</c>.</para></li></ul><para>Example: <c>2592000</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CommitmentDuration { get; set; }
        #endregion
        
        #region Parameter DBCapacityReservationName
        /// <summary>
        /// <para>
        /// <para>The name of the DB capacity reservation. This name must be unique for your Amazon
        /// Web Services account in the Amazon Web Services Region.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 lowercase letters, digits, or hyphens.</para></li><li><para>First character must be a lowercase letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Can't contain more than 16 groups of characters separated by hyphens.</para></li><li><para>Can't begin with <c>dbcr-</c>.</para></li></ul>
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
        public System.String DBCapacityReservationName { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity to reserve, for example <c>db.m5.large</c>. Not all
        /// DB instance classes are available in all Amazon Web Services Regions, or for all database
        /// engines. For the full list of DB instance classes, and availability for your engine,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// instance classes</a> in the <i>Amazon RDS User Guide</i>.</para><para>Constraints:</para><ul><li><para>Must be a DB instance class that the specified <c>Engine</c> supports.</para></li><li><para>For RDS for Oracle with <c>LicenseModel</c> set to <c>license-included</c>, some DB
        /// instance classes aren't supported. Either choose a supported DB instance class, or
        /// set <c>LicenseModel</c> to <c>bring-your-own-license</c>.</para></li></ul>
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
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The date and time when the reservation expires, in Universal Coordinated Time (UTC).
        /// If you don't specify a value, the reservation doesn't expire.</para><para>To change the expiration of an existing reservation, use <c>ModifyDBCapacityReservation</c>.
        /// That operation takes <c>EndDateType</c> along with <c>EndDate</c>.</para><para>Constraints:</para><ul><li><para>Must be a date and time in the future.</para></li><li><para>For a future-dated reservation, must be at or after <c>StartDate</c> plus <c>CommitmentDuration</c>.
        /// For example, a reservation that starts on 2026-12-01 with a 30-day commitment can't
        /// expire before 2026-12-31. To reserve capacity for one calendar month, set <c>CommitmentDuration</c>
        /// to 30 days or fewer, not to the length of the month.</para></li></ul><para>Example: <c>2026-12-31T23:59:59Z</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to reserve capacity for.</para><para>Valid Values: <c>aurora-mysql</c> | <c>aurora-postgresql</c> | <c>mysql</c> | <c>postgres</c>
        /// | <c>mariadb</c> | <c>oracle-ee</c> | <c>oracle-ee-cdb</c> | <c>oracle-se2</c> | <c>oracle-se2-cdb</c>
        /// | <c>sqlserver-ee</c> | <c>sqlserver-se</c> | <c>sqlserver-web</c> | <c>sqlserver-ex</c>
        /// | <c>sqlserver-dev-ee</c> | <c>sqlserver-dev-se</c> | <c>db2-ae</c> | <c>db2-ce</c>
        /// | <c>db2-se</c></para><note><para>The Developer Edition engines <c>sqlserver-dev-ee</c> and <c>sqlserver-dev-se</c>
        /// support no Multi-AZ DB instance and no read replica. Therefore, a reservation for
        /// either engine serves Single-AZ DB instances only.</para></note>
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
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>The license model to reserve capacity for. Specify this parameter only for RDS for
        /// Microsoft SQL Server Enterprise Edition, Standard Edition, and Developer Edition,
        /// for RDS for Oracle, or for RDS for Db2 Standard Edition and Advanced Edition. Amazon
        /// RDS rejects the request for any other engine. This includes Amazon Aurora, the Web
        /// and Express editions of RDS for Microsoft SQL Server, and RDS for Db2 Community Edition.</para><para>Valid Values:</para><ul><li><para>RDS for Microsoft SQL Server Enterprise Edition and Standard Edition - <c>license-included
        /// | bring-your-own-media</c></para></li><li><para>RDS for Microsoft SQL Server Developer Edition - <c>bring-your-own-license</c></para></li><li><para>RDS for Oracle - <c>bring-your-own-license | license-included</c></para></li><li><para>RDS for Db2 Standard Edition and Advanced Edition - <c>bring-your-own-license | marketplace-license</c></para></li></ul><para>A DB instance launches into the reservation only when the license model of the DB
        /// instance matches the license model of the reservation. For a reservation that holds
        /// no license model, Amazon RDS applies no license model check at launch.</para><para>For RDS for Microsoft SQL Server Enterprise Edition and Standard Edition, if you don't
        /// specify a value, Amazon RDS uses <c>license-included</c>.</para><para>For RDS for Microsoft SQL Server Developer Edition, if you don't specify a value,
        /// Amazon RDS uses <c>bring-your-own-license</c>. That is the only license model that
        /// these engines accept, and Amazon RDS rejects any other value.</para><para>For RDS for Oracle, if you don't specify a value, Amazon RDS uses the only orderable
        /// license model for the DB instance class. If more than one license model is orderable,
        /// you must specify one.</para><para>For RDS for Db2 Standard Edition and Advanced Edition, if you don't specify a value,
        /// Amazon RDS uses <c>bring-your-own-license</c>. To reserve capacity for Db2 DB instances
        /// that you license through Amazon Web Services Marketplace, specify <c>marketplace-license</c>.</para><note><para>For RDS for Oracle, the license models that you can reserve depend on the engine and
        /// the DB instance class. RDS for Oracle Enterprise Edition doesn't support <c>license-included</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseModel { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The date and time when the reservation starts, in Universal Coordinated Time (UTC).
        /// Specify this parameter to create a future-dated reservation. If you don't specify
        /// a value, the reservation starts immediately.</para><para>A reservation that starts later always carries a capacity commitment. Therefore, a
        /// request that specifies <c>StartDate</c> must also meet every constraint of a future-dated
        /// reservation, including the minimum reserved capacity in each Availability Zone.</para><para>Constraints:</para><ul><li><para>Must be from 5 to 120 days in the future.</para></li><li><para>You must also specify <c>CommitmentDuration</c>.</para></li></ul><para>Example: <c>2026-12-01T00:00:00Z</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartDate { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the DB capacity reservation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCapacityReservation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateDBCapacityReservationResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateDBCapacityReservationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBCapacityReservation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBCapacityReservationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBCapacityReservation (CreateDBCapacityReservation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateDBCapacityReservationResponse, NewRDSDBCapacityReservationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZone = new List<System.String>(this.AvailabilityZone);
            }
            #if MODULAR
            if (this.AvailabilityZone == null && ParameterWasBound(nameof(this.AvailabilityZone)))
            {
                WriteWarning("You are passing $null as a value for parameter AvailabilityZone which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CapacityPerAvailabilityZone = this.CapacityPerAvailabilityZone;
            #if MODULAR
            if (this.CapacityPerAvailabilityZone == null && ParameterWasBound(nameof(this.CapacityPerAvailabilityZone)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityPerAvailabilityZone which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CommitmentDuration = this.CommitmentDuration;
            context.DBCapacityReservationName = this.DBCapacityReservationName;
            #if MODULAR
            if (this.DBCapacityReservationName == null && ParameterWasBound(nameof(this.DBCapacityReservationName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBCapacityReservationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBInstanceClass = this.DBInstanceClass;
            #if MODULAR
            if (this.DBInstanceClass == null && ParameterWasBound(nameof(this.DBInstanceClass)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceClass which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndDate = this.EndDate;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LicenseModel = this.LicenseModel;
            context.StartDate = this.StartDate;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
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
            var request = new Amazon.RDS.Model.CreateDBCapacityReservationRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.CapacityPerAvailabilityZone != null)
            {
                request.CapacityPerAvailabilityZone = cmdletContext.CapacityPerAvailabilityZone.Value;
            }
            if (cmdletContext.CommitmentDuration != null)
            {
                request.CommitmentDuration = cmdletContext.CommitmentDuration.Value;
            }
            if (cmdletContext.DBCapacityReservationName != null)
            {
                request.DBCapacityReservationName = cmdletContext.DBCapacityReservationName;
            }
            if (cmdletContext.DBInstanceClass != null)
            {
                request.DBInstanceClass = cmdletContext.DBInstanceClass;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.RDS.Model.CreateDBCapacityReservationResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateDBCapacityReservationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateDBCapacityReservation");
            try
            {
                return client.CreateDBCapacityReservationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AvailabilityZone { get; set; }
            public System.Int32? CapacityPerAvailabilityZone { get; set; }
            public System.Int64? CommitmentDuration { get; set; }
            public System.String DBCapacityReservationName { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.DateTime? EndDate { get; set; }
            public System.String Engine { get; set; }
            public System.String LicenseModel { get; set; }
            public System.DateTime? StartDate { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RDS.Model.CreateDBCapacityReservationResponse, NewRDSDBCapacityReservationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCapacityReservation;
        }
        
    }
}
